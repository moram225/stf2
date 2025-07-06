using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using GroqSTT;

namespace GroqSTT
{
    public class FormAnalyzer
    {
        public static async Task AnalyzeFormAsync(string formId)
        {
            try
            {
                var formPath = Path.Combine(Directory.GetCurrentDirectory(), "forms", $"{formId}.json");
                
                if (!File.Exists(formPath))
                {
                    Console.WriteLine($"❌ Form file not found: {formPath}");
                    return;
                }

                var jsonContent = await File.ReadAllTextAsync(formPath);
                var form = JsonConvert.DeserializeObject<FormDefinition>(jsonContent);

                if (form == null)
                {
                    Console.WriteLine("❌ Failed to parse form JSON");
                    return;
                }

                Console.WriteLine($"📋 Form Analysis: {form.FormTitle}");
                Console.WriteLine($"🆔 Form ID: {form.FormId}");
                Console.WriteLine($"📊 Total Fields: {form.Fields.Count}");
                Console.WriteLine();

                // Group fields by type
                var fieldsByType = form.Fields.GroupBy(f => f.FieldType).OrderBy(g => g.Key);

                foreach (var group in fieldsByType)
                {
                    Console.WriteLine($"🔸 {group.Key.ToUpper()} fields ({group.Count()}):");
                    
                    foreach (var field in group.Take(10)) // Show first 10 of each type
                    {
                        if (!string.IsNullOrEmpty(field.FieldValue))
                        {
                            Console.WriteLine($"   • {field.FieldValue}");
                        }
                        else if (!string.IsNullOrEmpty(field.FieldName))
                        {
                            Console.WriteLine($"   • Field: {field.FieldName}");
                        }
                        else
                        {
                            Console.WriteLine($"   • Unnamed {field.FieldType} field");
                        }
                    }
                    
                    if (group.Count() > 10)
                    {
                        Console.WriteLine($"   ... and {group.Count() - 10} more");
                    }
                    Console.WriteLine();
                }

                // Show checkbox options (these are often the most interesting)
                var checkboxFields = form.Fields.Where(f => f.FieldType == "checkbox" && !string.IsNullOrEmpty(f.FieldValue)).ToList();
                if (checkboxFields.Any())
                {
                    Console.WriteLine("☑️ Available Checkbox Options:");
                    var groupedCheckboxes = checkboxFields.GroupBy(f => f.FieldName);
                    
                    foreach (var group in groupedCheckboxes)
                    {
                        Console.WriteLine($"   Group {group.Key}:");
                        foreach (var option in group)
                        {
                            Console.WriteLine($"     - {option.FieldValue}");
                        }
                        Console.WriteLine();
                    }
                }

                // Show text fields that might need input
                var textFields = form.Fields.Where(f => f.FieldType == "text" && string.IsNullOrEmpty(f.FieldValue)).ToList();
                if (textFields.Any())
                {
                    Console.WriteLine($"📝 Text Input Fields ({textFields.Count}):");
                    foreach (var field in textFields.Take(10))
                    {
                        Console.WriteLine($"   • {field.FieldName}");
                    }
                    if (textFields.Count > 10)
                    {
                        Console.WriteLine($"   ... and {textFields.Count - 10} more");
                    }
                    Console.WriteLine();
                }

                // Show select fields
                var selectFields = form.Fields.Where(f => f.FieldType == "select").ToList();
                if (selectFields.Any())
                {
                    Console.WriteLine($"📋 Select/Dropdown Fields ({selectFields.Count}):");
                    foreach (var field in selectFields)
                    {
                        Console.WriteLine($"   • {field.FieldName}");
                    }
                    Console.WriteLine();
                }

                // Show textarea fields
                var textareaFields = form.Fields.Where(f => f.FieldType == "textarea").ToList();
                if (textareaFields.Any())
                {
                    Console.WriteLine($"📄 Textarea Fields ({textareaFields.Count}):");
                    foreach (var field in textareaFields)
                    {
                        Console.WriteLine($"   • {field.FieldName}");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error analyzing form: {ex.Message}");
            }
        }

        public static async Task ListAvailableFormsAsync()
        {
            try
            {
                var formsDir = Path.Combine(Directory.GetCurrentDirectory(), "forms");
                
                if (!Directory.Exists(formsDir))
                {
                    Console.WriteLine("❌ Forms directory not found. Run option 4 to generate forms first.");
                    return;
                }

                var jsonFiles = Directory.GetFiles(formsDir, "*.json")
                    .Select(f => Path.GetFileNameWithoutExtension(f))
                    .OrderBy(f => f)
                    .ToList();

                if (!jsonFiles.Any())
                {
                    Console.WriteLine("❌ No form files found. Run option 4 to generate forms first.");
                    return;
                }

                Console.WriteLine($"📋 Available Forms ({jsonFiles.Count}):");
                Console.WriteLine("========================");

                foreach (var formId in jsonFiles.Take(20)) // Show first 20
                {
                    try
                    {
                        var formPath = Path.Combine(formsDir, $"{formId}.json");
                        var jsonContent = await File.ReadAllTextAsync(formPath);
                        var form = JsonConvert.DeserializeObject<FormDefinition>(jsonContent);
                        
                        if (form != null)
                        {
                            var fillableCount = form.Fields.Count(f => 
                                (f.FieldType == "text" || f.FieldType == "textarea" || f.FieldType == "select") &&
                                !string.IsNullOrEmpty(f.FieldName));
                            
                            Console.WriteLine($"🆔 {formId}");
                            Console.WriteLine($"   📋 {form.FormTitle}");
                            Console.WriteLine($"   📊 {fillableCount} fillable fields");
                            Console.WriteLine();
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"🆔 {formId} (parsing error)");
                        Console.WriteLine();
                    }
                }

                if (jsonFiles.Count > 20)
                {
                    Console.WriteLine($"... and {jsonFiles.Count - 20} more forms");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error listing forms: {ex.Message}");
            }
        }
    }
}
