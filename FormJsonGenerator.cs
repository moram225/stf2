using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace GroqSTT
{
    public class FormField
    {
        public string FieldName { get; set; } = "";
        public string FieldId { get; set; } = "";
        public string FieldType { get; set; } = "";
        public List<string> FieldClasses { get; set; } = new List<string>();
        public string FieldValue { get; set; } = "";
        public bool HasName { get; set; }
        public bool HasId { get; set; }
        public bool HasValue { get; set; }
    }

    public class FormDefinition
    {
        public string FormId { get; set; } = "";
        public string FormTitle { get; set; } = "";
        public List<FormField> Fields { get; set; } = new List<FormField>();
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
    }

    public class FormJsonGenerator
    {
        public static async Task GenerateFormsAsync()
        {
            try
            {
                var csvPath = Path.Combine(Directory.GetCurrentDirectory(), "forms labels", "detailed_fields_analysis.csv");
                var formsDir = Path.Combine(Directory.GetCurrentDirectory(), "forms");

                if (!File.Exists(csvPath))
                {
                    Console.WriteLine($"❌ CSV file not found: {csvPath}");
                    return;
                }

                Console.WriteLine("📊 Parsing CSV file...");
                var forms = await ParseCsvAsync(csvPath);

                Console.WriteLine($"📝 Found {forms.Count} unique forms");

                foreach (var form in forms)
                {
                    var jsonFileName = $"{form.FormId}.json";
                    var jsonPath = Path.Combine(formsDir, jsonFileName);

                    var jsonContent = JsonConvert.SerializeObject(form, Formatting.Indented);
                    await File.WriteAllTextAsync(jsonPath, jsonContent);

                    Console.WriteLine($"✅ Generated: {jsonFileName} ({form.Fields.Count} fields)");
                }

                Console.WriteLine($"🎉 Successfully generated {forms.Count} form JSON files in the forms/ folder");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error generating forms: {ex.Message}");
            }
        }

        private static async Task<List<FormDefinition>> ParseCsvAsync(string csvPath)
        {
            var lines = await File.ReadAllLinesAsync(csvPath);
            var forms = new Dictionary<string, FormDefinition>();

            // Skip header line
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = ParseCsvLine(line);
                if (parts.Length < 10) continue;

                var formId = parts[0];
                var formTitle = parts[1];
                var fieldName = parts[2];
                var fieldId = parts[3];
                var fieldType = parts[4];
                var fieldClassesStr = parts[5];
                var fieldValue = parts[6];
                var hasName = bool.Parse(parts[7]);
                var hasId = bool.Parse(parts[8]);
                var hasValue = bool.Parse(parts[9]);

                // Parse field classes from string representation
                var fieldClasses = new List<string>();
                if (!string.IsNullOrEmpty(fieldClassesStr) && fieldClassesStr != "[]")
                {
                    // Remove brackets and quotes, split by comma
                    var cleaned = fieldClassesStr.Trim('[', ']').Replace("'", "").Replace("\"", "");
                    if (!string.IsNullOrEmpty(cleaned))
                    {
                        fieldClasses = cleaned.Split(',').Select(c => c.Trim()).Where(c => !string.IsNullOrEmpty(c)).ToList();
                    }
                }

                // Get or create form definition
                if (!forms.ContainsKey(formId))
                {
                    forms[formId] = new FormDefinition
                    {
                        FormId = formId,
                        FormTitle = formTitle,
                        Fields = new List<FormField>(),
                        Metadata = new Dictionary<string, object>
                        {
                            { "generated_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                            { "source", "detailed_fields_analysis.csv" }
                        }
                    };
                }

                // Add field to form
                forms[formId].Fields.Add(new FormField
                {
                    FieldName = fieldName,
                    FieldId = fieldId,
                    FieldType = fieldType,
                    FieldClasses = fieldClasses,
                    FieldValue = fieldValue,
                    HasName = hasName,
                    HasId = hasId,
                    HasValue = hasValue
                });
            }

            return forms.Values.ToList();
        }

        private static string[] ParseCsvLine(string line)
        {
            var result = new List<string>();
            var inQuotes = false;
            var currentField = "";

            for (int i = 0; i < line.Length; i++)
            {
                var ch = line[i];

                if (ch == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (ch == ',' && !inQuotes)
                {
                    result.Add(currentField);
                    currentField = "";
                }
                else
                {
                    currentField += ch;
                }
            }

            result.Add(currentField); // Add the last field
            return result.ToArray();
        }
    }
}
