# API Reference - GroqDocs

<script type="text/javascript" crossorigin="anonymous" src="/a/static/dead-clicks-autocapture.js?v=1.249.0"></script><script type="text/javascript" crossorigin="anonymous" src="/a/static/exception-autocapture.js?v=1.249.0"></script><script type="text/javascript" crossorigin="anonymous" src="/a/static/surveys.js?v=1.249.0"></script><script type="text/javascript" crossorigin="anonymous" src="/a/array/phc_MrAAAWfjIrmzC8OHWp4uJWpv6lHCc4U2Hu8NDgyxCrl/config.js"></script><script type="text/javascript" crossorigin="anonymous" src="/a/static/dead-clicks-autocapture.js?v=1.249.0"></script><script type="text/javascript" crossorigin="anonymous" src="/a/static/dead-clicks-autocapture.js?v=1.249.0"></script><script type="text/javascript" crossorigin="anonymous" src="/a/static/exception-autocapture.js?v=1.249.0"></script><script type="text/javascript" crossorigin="anonymous" src="/a/static/exception-autocapture.js?v=1.249.0"></script><script type="text/javascript" crossorigin="anonymous" src="/a/static/dead-clicks-autocapture.js?v=1.249.0"></script><script type="text/javascript" crossorigin="anonymous" src="/a/static/dead-clicks-autocapture.js?v=1.249.0"></script><script type="text/javascript" crossorigin="anonymous" src="/a/static/recorder.js?v=1.249.0"></script><script>!function(){try{var d=document.documentElement,c=d.classList;c.remove('light','dark');var e=localStorage.getItem('theme');if('system'===e||(!e&&true)){var t='(prefers-color-scheme: dark)',m=window.matchMedia(t);if(m.media!==t||m.matches){d.style.colorScheme = 'dark';c.add('dark')}else{d.style.colorScheme = 'light';c.add('light')}}else if(e){c.add(e|| '')}if(e==='light'||e==='dark')d.style.colorScheme=e}catch(e){}}()</script>

[Groq Cloud](/)

[Groq Cloud](/)

[Playground](/playground)

[API Keys](/keys)

[Dashboard](/dashboard)

[Docs](/docs)

![Mo Ra](https://lh3.googleusercontent.com/a/ACg8ocJvQgSn-5uNlGilJdQx4plFWVFKa8tAru3MGjRFxhXnAyjcl34=s96-c)Personal

[Playground](/playground)

[API Keys](/keys)

[Dashboard](/dashboard)

[Docs](/docs)

![Mo Ra](https://lh3.googleusercontent.com/a/ACg8ocJvQgSn-5uNlGilJdQx4plFWVFKa8tAru3MGjRFxhXnAyjcl34=s96-c)Personal

## Documentation

[Docs](/docs/overview)

[API Reference](/docs/api-reference)

SearchK

Audio

## API Reference

endpoints

[Chat](api-reference#chat)[Create chat completion](api-reference#chat-create)[Audio](api-reference#audio)[Create transcription](api-reference#audio-transcription)[Create translation](api-reference#audio-translation)[Create speech](api-reference#audio-speech)[Models](api-reference#models)[List models](api-reference#models-list)[Retrieve model](api-reference#models-retrieve)[Batches](api-reference#batches)[Create batch](api-reference#batches-create)[Retrieve batch](api-reference#batches-retrieve)[List batches](api-reference#batches-list)[Cancel batch](api-reference#batches-cancel)[Files](api-reference#files)[Upload file](api-reference#files-upload)[List files](api-reference#files-list)[Delete file](api-reference#files-delete)[Retrieve file](api-reference#files-retrieve)[Download file](api-reference#files-download)

SearchK

[Docs](/docs/overview)

[API Reference](/docs/api-reference)

endpoints

[Chat](api-reference#chat)

[Audio](api-reference#audio)

[Create transcription](api-reference#audio-transcription)[Create translation](api-reference#audio-translation)[Create speech](api-reference#audio-speech)

[Models](api-reference#models)

[Batches](api-reference#batches)

[Files](api-reference#files)

## [Groq API Reference](#groq-api-reference)

[

## Chat

](api-reference#chat)

[

### Create chat completion

](api-reference#chat-create)

POSThttps://api.groq.com/openai/v1/chat/completions

Creates a model response for the given chat conversation.

### 

[

#### Request Body

](api-reference#chat-create-request-body)

-   messagesarrayRequired
    
    A list of messages comprising the conversation so far.
    
    ### Show possible types
    
-   modelstringRequired
    
    ID of the model to use. For details on which models are compatible with the Chat API, see available [models](https://console.groq.com/docs/models)
    
-   exclude\_domainsDeprecatedarray or nullOptional
    
    Deprecated: Use search\_settings.exclude\_domains instead. A list of domains to exclude from the search results when the model uses a web search tool.
    
-   frequency\_penaltynumber or nullOptionalDefaults to 0
    
    Range: -2 - 2
    
    Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim.
    
-   function\_callDeprecatedstring / object or nullOptional
    
    Deprecated in favor of `tool_choice`.
    
    Controls which (if any) function is called by the model. `none` means the model will not call a function and instead generates a message. `auto` means the model can pick between generating a message or calling a function. Specifying a particular function via `{"name": "my_function"}` forces the model to call that function.
    
    `none` is the default when no functions are present. `auto` is the default if functions are present.
    
    ### Show possible types
    
-   functionsDeprecatedarray or nullOptional
    
    Deprecated in favor of `tools`.
    
    A list of functions the model may generate JSON inputs for.
    
    ### Show properties
    
-   include\_domainsDeprecatedarray or nullOptional
    
    Deprecated: Use search\_settings.include\_domains instead. A list of domains to include in the search results when the model uses a web search tool.
    
-   logit\_biasobject or nullOptional
    
    This is not yet supported by any of our models. Modify the likelihood of specified tokens appearing in the completion.
    
-   logprobsboolean or nullOptionalDefaults to false
    
    This is not yet supported by any of our models. Whether to return log probabilities of the output tokens or not. If true, returns the log probabilities of each output token returned in the `content` of `message`.
    
-   max\_completion\_tokensinteger or nullOptional
    
    The maximum number of tokens that can be generated in the chat completion. The total length of input tokens and generated tokens is limited by the model's context length.
    
-   max\_tokensDeprecatedinteger or nullOptional
    
    Deprecated in favor of `max_completion_tokens`. The maximum number of tokens that can be generated in the chat completion. The total length of input tokens and generated tokens is limited by the model's context length.
    
-   metadataobject or nullOptional
    
    This parameter is not currently supported.
    
-   ninteger or nullOptionalDefaults to 1
    
    Range: 1 - 1
    
    How many chat completion choices to generate for each input message. Note that the current moment, only n=1 is supported. Other values will result in a 400 response.
    
-   parallel\_tool\_callsboolean or nullOptionalDefaults to true
    
    Whether to enable parallel function calling during tool use.
    
-   presence\_penaltynumber or nullOptionalDefaults to 0
    
    Range: -2 - 2
    
    Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics.
    
-   reasoning\_effortstring or nullOptional
    
    Allowed values: `none, default`
    
    this field is only available for qwen3 models. Set to 'none' to disable reasoning. Set to 'default' or null to let Qwen reason.
    
-   reasoning\_formatstring or nullOptional
    
    Allowed values: `hidden, raw, parsed`
    
    Specifies how to output reasoning tokens
    
-   response\_formatobject / object / object or nullOptional
    
    An object specifying the format that the model must output. Setting to `{ "type": "json_schema", "json_schema": {...} }` enables Structured Outputs which ensures the model will match your supplied JSON schema. json\_schema response format is only supported on llama 4 models. Setting to `{ "type": "json_object" }` enables the older JSON mode, which ensures the message the model generates is valid JSON. Using `json_schema` is preferred for models that support it.
    
    ### Show possible types
    
-   search\_settingsobject or nullOptional
    
    Settings for web search functionality when the model uses a web search tool.
    
    ### Show properties
    
    exclude\_domainsarray or nullOptional
    
    A list of domains to exclude from the search results.
    
    include\_domainsarray or nullOptional
    
    A list of domains to include in the search results.
    
    include\_imagesboolean or nullOptional
    
    Whether to include images in the search results.
    
-   seedinteger or nullOptional
    
    If specified, our system will make a best effort to sample deterministically, such that repeated requests with the same `seed` and parameters should return the same result. Determinism is not guaranteed, and you should refer to the `system_fingerprint` response parameter to monitor changes in the backend.
    
-   service\_tierstring or nullOptional
    
    Allowed values: `auto, on_demand, flex, null`
    
    The service tier to use for the request. Defaults to `on_demand`.
    
    -   `auto` will automatically select the highest tier available within the rate limits of your organization.
    -   `flex` uses the flex tier, which will succeed or fail quickly.
    
-   stopstring / array or nullOptional
    
    Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.
    
    ### Show possible types
    
-   storeboolean or nullOptional
    
    This parameter is not currently supported.
    
-   streamboolean or nullOptionalDefaults to false
    
    If set, partial message deltas will be sent. Tokens will be sent as data-only [server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format) as they become available, with the stream terminated by a `data: [DONE]` message. [Example code](/docs/text-chat#streaming-a-chat-completion).
    
-   stream\_optionsobject or nullOptional
    
    Options for streaming response. Only set this when you set `stream: true`.
    
    ### Show properties
    
-   temperaturenumber or nullOptionalDefaults to 1
    
    Range: 0 - 2
    
    What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. We generally recommend altering this or top\_p but not both.
    
-   tool\_choicestring / object or nullOptional
    
    Controls which (if any) tool is called by the model. `none` means the model will not call any tool and instead generates a message. `auto` means the model can pick between generating a message or calling one or more tools. `required` means the model must call one or more tools. Specifying a particular tool via `{"type": "function", "function": {"name": "my_function"}}` forces the model to call that tool.
    
    `none` is the default when no tools are present. `auto` is the default if tools are present.
    
    ### Show possible types
    
-   toolsarray or nullOptional
    
    A list of tools the model may call. Currently, only functions are supported as a tool. Use this to provide a list of functions the model may generate JSON inputs for. A max of 128 functions are supported.
    
    ### Show properties
    
-   top\_logprobsinteger or nullOptional
    
    Range: 0 - 20
    
    This is not yet supported by any of our models. An integer between 0 and 20 specifying the number of most likely tokens to return at each token position, each with an associated log probability. `logprobs` must be set to `true` if this parameter is used.
    
-   top\_pnumber or nullOptionalDefaults to 1
    
    Range: 0 - 1
    
    An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top\_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. We generally recommend altering this or temperature but not both.
    
-   userstring or nullOptional
    
    A unique identifier representing your end-user, which can help us monitor and detect abuse.
    

### 

[

#### Returns

](api-reference#chat-create-returns)

Returns a [chat completion](/docs/api-reference#chat-create) object, or a streamed sequence of [chat completion chunk](/docs/api-reference#chat-create) objects if the request is streamed.

curl

```
curl https://api.groq.com/openai/v1/chat/completions -s \
-H "Content-Type: application/json" \
-H "Authorization: Bearer $GROQ_API_KEY" \
-d '{
  "model": "llama-3.3-70b-versatile",
  "messages": [{
      "role": "user",
      "content": "Explain the importance of fast language models"
  }]
}'
```

JSON

```
{
  "id": "chatcmpl-f51b2cd2-bef7-417e-964e-a08f0b513c22",
  "object": "chat.completion",
  "created": 1730241104,
  "model": "llama3-8b-8192",
  "choices": [
    {
      "index": 0,
      "message": {
        "role": "assistant",
        "content": "Fast language models have gained significant attention in recent years due to their ability to process and generate human-like text quickly and efficiently. The importance of fast language models can be understood from their potential applications and benefits:\n\n1. **Real-time Chatbots and Conversational Interfaces**: Fast language models enable the development of chatbots and conversational interfaces that can respond promptly to user queries, making them more engaging and useful.\n2. **Sentiment Analysis and Opinion Mining**: Fast language models can quickly analyze text data to identify sentiments, opinions, and emotions, allowing for improved customer service, market research, and opinion mining.\n3. **Language Translation and Localization**: Fast language models can quickly translate text between languages, facilitating global communication and enabling businesses to reach a broader audience.\n4. **Text Summarization and Generation**: Fast language models can summarize long documents or even generate new text on a given topic, improving information retrieval and processing efficiency.\n5. **Named Entity Recognition and Information Extraction**: Fast language models can rapidly recognize and extract specific entities, such as names, locations, and organizations, from unstructured text data.\n6. **Recommendation Systems**: Fast language models can analyze large amounts of text data to personalize product recommendations, improve customer experience, and increase sales.\n7. **Content Generation for Social Media**: Fast language models can quickly generate engaging content for social media platforms, helping businesses maintain a consistent online presence and increasing their online visibility.\n8. **Sentiment Analysis for Stock Market Analysis**: Fast language models can quickly analyze social media posts, news articles, and other text data to identify sentiment trends, enabling financial analysts to make more informed investment decisions.\n9. **Language Learning and Education**: Fast language models can provide instant feedback and adaptive language learning, making language education more effective and engaging.\n10. **Domain-Specific Knowledge Extraction**: Fast language models can quickly extract relevant information from vast amounts of text data, enabling domain experts to focus on high-level decision-making rather than manual information gathering.\n\nThe benefits of fast language models include:\n\n* **Increased Efficiency**: Fast language models can process large amounts of text data quickly, reducing the time and effort required for tasks such as sentiment analysis, entity recognition, and text summarization.\n* **Improved Accuracy**: Fast language models can analyze and learn from large datasets, leading to more accurate results and more informed decision-making.\n* **Enhanced User Experience**: Fast language models can enable real-time interactions, personalized recommendations, and timely responses, improving the overall user experience.\n* **Cost Savings**: Fast language models can automate many tasks, reducing the need for manual labor and minimizing costs associated with data processing and analysis.\n\nIn summary, fast language models have the potential to transform various industries and applications by providing fast, accurate, and efficient language processing capabilities."
      },
      "logprobs": null,
      "finish_reason": "stop"
    }
  ],
  "usage": {
    "queue_time": 0.037493756,
    "prompt_tokens": 18,
    "prompt_time": 0.000680594,
    "completion_tokens": 556,
    "completion_time": 0.463333333,
    "total_tokens": 574,
    "total_time": 0.464013927
  },
  "system_fingerprint": "fp_179b0f92c9",
  "x_groq": { "id": "req_01jbd6g2qdfw2adyrt2az8hz4w" }
}
```

[

## Audio

](api-reference#audio)

[

### Create transcription

](api-reference#audio-transcription)

POSThttps://api.groq.com/openai/v1/audio/transcriptions

Transcribes audio into the input language.

### 

[

#### Request Body

](api-reference#audio-transcription-request-body)

-   modelstringRequired
    
    ID of the model to use. `whisper-large-v3` and `whisper-large-v3-turbo` are currently available.
    
-   filestringOptional
    
    The audio file object (not file name) to transcribe, in one of these formats: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, or webm. Either a file or a URL must be provided. Note that the file field is not supported in Batch API requests.
    
-   languagestringOptional
    
    The language of the input audio. Supplying the input language in [ISO-639-1](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes) format will improve accuracy and latency.
    
-   promptstringOptional
    
    An optional text to guide the model's style or continue a previous audio segment. The [prompt](/docs/speech-text) should match the audio language.
    
-   response\_formatstringOptionalDefaults to json
    
    Allowed values: `json, text, verbose_json`
    
    The format of the transcript output, in one of these options: `json`, `text`, or `verbose_json`.
    
-   temperaturenumberOptionalDefaults to 0
    
    The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. If set to 0, the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to automatically increase the temperature until certain thresholds are hit.
    
-   timestamp\_granularities\[\]arrayOptionalDefaults to segment
    
    The timestamp granularities to populate for this transcription. `response_format` must be set `verbose_json` to use timestamp granularities. Either or both of these options are supported: `word`, or `segment`. Note: There is no additional latency for segment timestamps, but generating word timestamps incurs additional latency.
    
-   urlstringOptional
    
    The audio URL to translate/transcribe (supports Base64URL). Either a file or a URL must be provided. For Batch API requests, the URL field is required since the file field is not supported.
    

### 

[

#### Returns

](api-reference#audio-transcription-returns)

Returns an audio transcription object.

curl

```
curl https://api.groq.com/openai/v1/audio/transcriptions \
  -H "Authorization: Bearer $GROQ_API_KEY" \
  -H "Content-Type: multipart/form-data" \
  -F file="@./sample_audio.m4a" \
  -F model="whisper-large-v3"
```

JSON

```
{
  "text": "Your transcribed text appears here...",
  "x_groq": {
    "id": "req_unique_id"
  }
}
```

[

### Create translation

](api-reference#audio-translation)

POSThttps://api.groq.com/openai/v1/audio/translations

Translates audio into English.

### 

[

#### Request Body

](api-reference#audio-translation-request-body)

-   modelstringRequired
    
    ID of the model to use. `whisper-large-v3` and `whisper-large-v3-turbo` are currently available.
    
-   filestringOptional
    
    The audio file object (not file name) translate, in one of these formats: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, or webm.
    
-   promptstringOptional
    
    An optional text to guide the model's style or continue a previous audio segment. The [prompt](/docs/guides/speech-to-text/prompting) should be in English.
    
-   response\_formatstringOptionalDefaults to json
    
    Allowed values: `json, text, verbose_json`
    
    The format of the transcript output, in one of these options: `json`, `text`, or `verbose_json`.
    
-   temperaturenumberOptionalDefaults to 0
    
    The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. If set to 0, the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to automatically increase the temperature until certain thresholds are hit.
    
-   urlstringOptional
    
    The audio URL to translate/transcribe (supports Base64URL). Either file or url must be provided. When using the Batch API only url is supported.
    

### 

[

#### Returns

](api-reference#audio-translation-returns)

Returns an audio translation object.

curl

```
curl https://api.groq.com/openai/v1/audio/translations \
  -H "Authorization: Bearer $GROQ_API_KEY" \
  -H "Content-Type: multipart/form-data" \
  -F file="@./sample_audio.m4a" \
  -F model="whisper-large-v3"
```

JSON

```
{
  "text": "Your translated text appears here...",
  "x_groq": {
    "id": "req_unique_id"
  }
}
```

[

### Create speech

](api-reference#audio-speech)

POSThttps://api.groq.com/openai/v1/audio/speech

Generates audio from the input text.

### 

[

#### Request Body

](api-reference#audio-speech-request-body)

-   inputstringRequired
    
    The text to generate audio for.
    
-   modelstringRequired
    
    One of the [available TTS models](/docs/text-to-speech).
    
-   voicestringRequired
    
    The voice to use when generating the audio. List of voices can be found [here](/docs/text-to-speech).
    
-   response\_formatstringOptionalDefaults to mp3
    
    Allowed values: `flac, mp3, mulaw, ogg, wav`
    
    The format of the generated audio. Supported formats are `flac, mp3, mulaw, ogg, wav`.
    
-   sample\_rateintegerOptionalDefaults to 48000
    
    Allowed values: `8000, 16000, 22050, 24000, 32000, 44100, 48000`
    
    The sample rate for generated audio
    
-   speednumberOptionalDefaults to 1
    
    Range: 0.5 - 5
    
    The speed of the generated audio.
    

### 

[

#### Returns

](api-reference#audio-speech-returns)

Returns an audio file in `wav` format.

curl

```
curl https://api.groq.com/openai/v1/audio/speech \
  -H "Authorization: Bearer $GROQ_API_KEY" \
  -H "Content-Type: application/json" \
  -d '{
    "model": "playai-tts",
    "input": "I love building and shipping new features for our users!",
    "voice": "Fritz-PlayAI",
    "response_format": "wav"
  }'
```

[

## Models

](api-reference#models)

[

### List models

](api-reference#models-list)

GEThttps://api.groq.com/openai/v1/models

List all available [models](https://console.groq.com/docs/models).

### 

[

#### Returns

](api-reference#models-list-returns)

A list of model objects.

curl

```
curl https://api.groq.com/openai/v1/models \
-H "Authorization: Bearer $GROQ_API_KEY"
```

JSON

```
{
  "object": "list",
  "data": [
    {
      "id": "gemma2-9b-it",
      "object": "model",
      "created": 1693721698,
      "owned_by": "Google",
      "active": true,
      "context_window": 8192,
      "public_apps": null
    },
    {
      "id": "llama3-8b-8192",
      "object": "model",
      "created": 1693721698,
      "owned_by": "Meta",
      "active": true,
      "context_window": 8192,
      "public_apps": null
    },
    {
      "id": "llama3-70b-8192",
      "object": "model",
      "created": 1693721698,
      "owned_by": "Meta",
      "active": true,
      "context_window": 8192,
      "public_apps": null
    },
    {
      "id": "whisper-large-v3-turbo",
      "object": "model",
      "created": 1728413088,
      "owned_by": "OpenAI",
      "active": true,
      "context_window": 448,
      "public_apps": null
    },
    {
      "id": "whisper-large-v3",
      "object": "model",
      "created": 1693721698,
      "owned_by": "OpenAI",
      "active": true,
      "context_window": 448,
      "public_apps": null
    },
    {
      "id": "llama-guard-3-8b",
      "object": "model",
      "created": 1693721698,
      "owned_by": "Meta",
      "active": true,
      "context_window": 8192,
      "public_apps": null
    },
    {
      "id": "distil-whisper-large-v3-en",
      "object": "model",
      "created": 1693721698,
      "owned_by": "Hugging Face",
      "active": true,
      "context_window": 448,
      "public_apps": null
    },
    {
      "id": "llama-3.1-8b-instant",
      "object": "model",
      "created": 1693721698,
      "owned_by": "Meta",
      "active": true,
      "context_window": 131072,
      "public_apps": null
    }
  ]
}
```

[

### Retrieve model

](api-reference#models-retrieve)

GEThttps://api.groq.com/openai/v1/models/{model}

Get detailed information about a [model](https://console.groq.com/docs/models).

### 

[

#### Returns

](api-reference#models-retrieve-returns)

A model object.

curl

```
curl https://api.groq.com/openai/v1/models/llama-3.3-70b-versatile \
-H "Authorization: Bearer $GROQ_API_KEY"
```

JSON

```
{
  "id": "llama3-8b-8192",
  "object": "model",
  "created": 1693721698,
  "owned_by": "Meta",
  "active": true,
  "context_window": 8192,
  "public_apps": null,
  "max_completion_tokens": 8192
}
```

[

## Batches

](api-reference#batches)

[

### Create batch

](api-reference#batches-create)

POSThttps://api.groq.com/openai/v1/batches

Creates and executes a batch from an uploaded file of requests. [Learn more](/docs/batch).

### 

[

#### Request Body

](api-reference#batches-create-request-body)

-   completion\_windowstringRequired
    
    The time frame within which the batch should be processed. Durations from `24h` to `7d` are supported.
    
-   endpointstringRequired
    
    Allowed values: `/v1/chat/completions`
    
    The endpoint to be used for all requests in the batch. Currently `/v1/chat/completions` is supported.
    
-   input\_file\_idstringRequired
    
    The ID of an uploaded file that contains requests for the new batch.
    
    See [upload file](/docs/api-reference#files-upload) for how to upload a file.
    
    Your input file must be formatted as a [JSONL file](/docs/batch), and must be uploaded with the purpose `batch`. The file can be up to 100 MB in size.
    
-   metadataobject or nullOptional
    
    Optional custom metadata for the batch.
    

### 

[

#### Returns

](api-reference#batches-create-returns)

A created batch object.

curl

```
curl https://api.groq.com/openai/v1/batches \
  -H "Authorization: Bearer $GROQ_API_KEY" \
  -H "Content-Type: application/json" \
  -d '{
    "input_file_id": "file_01jh6x76wtemjr74t1fh0faj5t",
    "endpoint": "/v1/chat/completions",
    "completion_window": "24h"
  }'
```

JSON

```
{
  "id": "batch_01jh6xa7reempvjyh6n3yst2zw",
  "object": "batch",
  "endpoint": "/v1/chat/completions",
  "errors": null,
  "input_file_id": "file_01jh6x76wtemjr74t1fh0faj5t",
  "completion_window": "24h",
  "status": "validating",
  "output_file_id": null,
  "error_file_id": null,
  "finalizing_at": null,
  "failed_at": null,
  "expired_at": null,
  "cancelled_at": null,
  "request_counts": {
    "total": 0,
    "completed": 0,
    "failed": 0
  },
  "metadata": null,
  "created_at": 1736472600,
  "expires_at": 1736559000,
  "cancelling_at": null,
  "completed_at": null,
  "in_progress_at": null
}
```

[

### Retrieve batch

](api-reference#batches-retrieve)

GEThttps://api.groq.com/openai/v1/batches/{batch\_id}

Retrieves a batch.

### 

[

#### Returns

](api-reference#batches-retrieve-returns)

A batch object.

curl

```
curl https://api.groq.com/openai/v1/batches/batch_01jh6xa7reempvjyh6n3yst2zw \
  -H "Authorization: Bearer $GROQ_API_KEY" \
  -H "Content-Type: application/json"
```

JSON

```
{
  "id": "batch_01jh6xa7reempvjyh6n3yst2zw",
  "object": "batch",
  "endpoint": "/v1/chat/completions",
  "errors": null,
  "input_file_id": "file_01jh6x76wtemjr74t1fh0faj5t",
  "completion_window": "24h",
  "status": "validating",
  "output_file_id": null,
  "error_file_id": null,
  "finalizing_at": null,
  "failed_at": null,
  "expired_at": null,
  "cancelled_at": null,
  "request_counts": {
    "total": 0,
    "completed": 0,
    "failed": 0
  },
  "metadata": null,
  "created_at": 1736472600,
  "expires_at": 1736559000,
  "cancelling_at": null,
  "completed_at": null,
  "in_progress_at": null
}
```

[

### List batches

](api-reference#batches-list)

GEThttps://api.groq.com/openai/v1/batches

List your organization's batches.

### 

[

#### Returns

](api-reference#batches-list-returns)

A list of batches

curl

```
curl https://api.groq.com/openai/v1/batches \
  -H "Authorization: Bearer $GROQ_API_KEY" \
  -H "Content-Type: application/json"
```

JSON

```
{
  "object": "list",
  "data": [
    {
      "id": "batch_01jh6xa7reempvjyh6n3yst2zw",
      "object": "batch",
      "endpoint": "/v1/chat/completions",
      "errors": null,
      "input_file_id": "file_01jh6x76wtemjr74t1fh0faj5t",
      "completion_window": "24h",
      "status": "validating",
      "output_file_id": null,
      "error_file_id": null,
      "finalizing_at": null,
      "failed_at": null,
      "expired_at": null,
      "cancelled_at": null,
      "request_counts": {
        "total": 0,
        "completed": 0,
        "failed": 0
      },
      "metadata": null,
      "created_at": 1736472600,
      "expires_at": 1736559000,
      "cancelling_at": null,
      "completed_at": null,
      "in_progress_at": null
    }
  ]
}
```

[

### Cancel batch

](api-reference#batches-cancel)

POSThttps://api.groq.com/openai/v1/batches/{batch\_id}/cancel

Cancels a batch.

### 

[

#### Returns

](api-reference#batches-cancel-returns)

A batch object.

curl

```
curl -X POST https://api.groq.com/openai/v1/batches/batch_01jh6xa7reempvjyh6n3yst2zw/cancel \
  -H "Authorization: Bearer $GROQ_API_KEY" \
  -H "Content-Type: application/json"
```

JSON

```
{
  "id": "batch_01jh6xa7reempvjyh6n3yst2zw",
  "object": "batch",
  "endpoint": "/v1/chat/completions",
  "errors": null,
  "input_file_id": "file_01jh6x76wtemjr74t1fh0faj5t",
  "completion_window": "24h",
  "status": "cancelling",
  "output_file_id": null,
  "error_file_id": null,
  "finalizing_at": null,
  "failed_at": null,
  "expired_at": null,
  "cancelled_at": null,
  "request_counts": {
    "total": 0,
    "completed": 0,
    "failed": 0
  },
  "metadata": null,
  "created_at": 1736472600,
  "expires_at": 1736559000,
  "cancelling_at": null,
  "completed_at": null,
  "in_progress_at": null
}
```

[

## Files

](api-reference#files)

[

### Upload file

](api-reference#files-upload)

POSThttps://api.groq.com/openai/v1/files

Upload a file that can be used across various endpoints.

The Batch API only supports `.jsonl` files up to 100 MB in size. The input also has a specific required [format](/docs/batch).

Please contact us if you need to increase these storage limits.

### 

[

#### Request Body

](api-reference#files-upload-request-body)

-   filestringRequired
    
    The File object (not file name) to be uploaded.
    
-   purposestringRequired
    
    Allowed values: `batch`
    
    The intended purpose of the uploaded file. Use "batch" for [Batch API](/docs/api-reference#batches).
    

### 

[

#### Returns

](api-reference#files-upload-returns)

The uploaded File object.

curl

```
curl https://api.groq.com/openai/v1/files \
  -H "Authorization: Bearer $GROQ_API_KEY" \
  -F purpose="batch" \
  -F "file=@batch_file.jsonl"
```

JSON

```
{
  "id": "file_01jh6x76wtemjr74t1fh0faj5t",
  "object": "file",
  "bytes": 966,
  "created_at": 1736472501,
  "filename": "batch_file.jsonl",
  "purpose": "batch"
}
```

[

### List files

](api-reference#files-list)

GEThttps://api.groq.com/openai/v1/files

Returns a list of files.

### 

[

#### Returns

](api-reference#files-list-returns)

A list of [File](/docs/api-reference#files-upload) objects.

curl

```
curl https://api.groq.com/openai/v1/files \
  -H "Authorization: Bearer $GROQ_API_KEY" \
  -H "Content-Type: application/json"
```

JSON

```
{
  "object": "list",
  "data": [
    {
      "id": "file_01jh6x76wtemjr74t1fh0faj5t",
      "object": "file",
      "bytes": 966,
      "created_at": 1736472501,
      "filename": "batch_file.jsonl",
      "purpose": "batch"
    }
  ]
}
```

[

### Delete file

](api-reference#files-delete)

DELETEhttps://api.groq.com/openai/v1/files/{file\_id}

Delete a file.

### 

[

#### Returns

](api-reference#files-delete-returns)

A deleted file response object.

curl

```
curl -X DELETE https://api.groq.com/openai/v1/files/file_01jh6x76wtemjr74t1fh0faj5t \
  -H "Authorization: Bearer $GROQ_API_KEY" \
  -H "Content-Type: application/json"
```

JSON

```
{
  "id": "file_01jh6x76wtemjr74t1fh0faj5t",
  "object": "file",
  "deleted": true
}
```

[

### Retrieve file

](api-reference#files-retrieve)

GEThttps://api.groq.com/openai/v1/files/{file\_id}

Returns information about a file.

### 

[

#### Returns

](api-reference#files-retrieve-returns)

A file object.

curl

```
curl https://api.groq.com/openai/v1/files/file_01jh6x76wtemjr74t1fh0faj5t \
  -H "Authorization: Bearer $GROQ_API_KEY" \
  -H "Content-Type: application/json"
```

JSON

```
{
  "id": "file_01jh6x76wtemjr74t1fh0faj5t",
  "object": "file",
  "bytes": 966,
  "created_at": 1736472501,
  "filename": "batch_file.jsonl",
  "purpose": "batch"
}
```

[

### Download file

](api-reference#files-download)

GEThttps://api.groq.com/openai/v1/files/{file\_id}/content

Returns the contents of the specified file.

### 

[

#### Returns

](api-reference#files-download-returns)

The file content

curl

```
curl https://api.groq.com/openai/v1/files/file_01jh6x76wtemjr74t1fh0faj5t/content \
  -H "Authorization: Bearer $GROQ_API_KEY" \
  -H "Content-Type: application/json"
```

<script src="/_next/static/chunks/webpack-595b26c25f7685e2.js" async=""></script><script>(self.__next_f=self.__next_f||[]).push([0])</script><script>self.__next_f.push([1,"1:\"$Sreact.fragment\"\n3:I[43705,[],\"ClientSegmentRoot\"]\n4:I[13417,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"4913\",\"static/chunks/4913-4ea28f93261ac149.js\",\"2721\",\"static/chunks/2721-386e7e50f093ad1d.js\",\"6689\",\"static/chunks/6689-dd753e9b53422d74.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"7267\",\"static/chunks/7267-f0f5047cdc5c0071.js\",\"1682\",\"static/chunks/1682-fe5b6177f2c1a97a.js\",\"9045\",\"static/chunks/9045-278ec3e8b4b3a58f.js\",\"74\",\"static/chunks/74-c88803b3b013ce58.js\",\"2540\",\"static/chunks/2540-5770462f0e4bfa9e.js\",\"210\",\"static/chunks/210-073740ea9519245f.js\",\"9870\",\"static/chunks/app/(console)/layout-1e6efd316c45ff34.js\"],\"default\"]\n5:I[65538,[],\"\"]\n6:I[96144,[],\"\"]\n9:I[93484,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"4913\",\"static/chunks/4913-4ea28f93261ac149.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"8338\",\"static/chunks/8338-940e18c510b3c6b4.js\",\"3148\",\"static/chunks/app/(console)/docs/(mdx-pages)/layout-25b2cd7fda065e74.js\"],\"FeedbackCollector\"]\na:I[93638,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"4913\",\"static/chunks/4913-4ea28f93261ac149.js\",\"2721\",\"static/chunks/2721-386e7e50f093ad1d.js\",\"6689\",\"static/chunks/6689-dd753e9b53422d74.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"9067\",\"static/chunks/9067-782484bebf0a2834.js\",\"4910\",\"static/chunks/4910-00fb342a68dc875b.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"3895\",\"static/chunks/3895-1ab7397e3e21938b.js\",\"7267\",\"static/chunks/7267-f0f5047cdc5c0071.js\",\"5015\",\"static/chunks/5015-e23efc6724184a73.js\",\"1682\",\"static/chunks/1682-fe5b6177f2c1a97a.js\",\"9045\",\"static/chunks/9045-278ec3e8b4b3a58f.js\",\"8429\",\"static/chunks/8429-62579fca5f687ae8.js\",\"74\",\"static/chunks/74-c88803b3b013ce58.js\",\"200\",\"static/chunks/200-7e3b6f6e0e7f03c5.js\",\"3626\",\"static/chunks/3626-9337d7c762494d1d.js\",\"210\",\"static/chunks/2"])</script><script>self.__next_f.push([1,"10-073740ea9519245f.js\",\"7474\",\"static/chunks/7474-0a7b236f9a97fc33.js\",\"5348\",\"static/chunks/5348-c66ef010d86bd2f3.js\",\"3619\",\"static/chunks/3619-6fe66cbf29d0baeb.js\",\"8528\",\"static/chunks/app/(console)/docs/(mdx-pages)/speech-to-text/page-5c9b7aa7f078d443.js\"],\"CopyableCode\"]\nb:I[82391,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"4913\",\"static/chunks/4913-4ea28f93261ac149.js\",\"2721\",\"static/chunks/2721-386e7e50f093ad1d.js\",\"6689\",\"static/chunks/6689-dd753e9b53422d74.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"9067\",\"static/chunks/9067-782484bebf0a2834.js\",\"4910\",\"static/chunks/4910-00fb342a68dc875b.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"3895\",\"static/chunks/3895-1ab7397e3e21938b.js\",\"7267\",\"static/chunks/7267-f0f5047cdc5c0071.js\",\"5015\",\"static/chunks/5015-e23efc6724184a73.js\",\"1682\",\"static/chunks/1682-fe5b6177f2c1a97a.js\",\"9045\",\"static/chunks/9045-278ec3e8b4b3a58f.js\",\"8429\",\"static/chunks/8429-62579fca5f687ae8.js\",\"74\",\"static/chunks/74-c88803b3b013ce58.js\",\"200\",\"static/chunks/200-7e3b6f6e0e7f03c5.js\",\"3626\",\"static/chunks/3626-9337d7c762494d1d.js\",\"210\",\"static/chunks/210-073740ea9519245f.js\",\"7474\",\"static/chunks/7474-0a7b236f9a97fc33.js\",\"5348\",\"static/chunks/5348-c66ef010d86bd2f3.js\",\"3619\",\"static/chunks/3619-6fe66cbf29d0baeb.js\",\"8528\",\"static/chunks/app/(console)/docs/(mdx-pages)/speech-to-text/page-5c9b7aa7f078d443.js\"],\"\"]\nc:I[7474,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"4913\",\"static/chunks/4913-4ea28f93261ac149.js\",\"2721\",\"static/chunks/2721-386e7e50f093ad1d.js\",\"6689\",\"static/chunks/6689-dd753e9b53422d74.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"9067\",\"static/chunks/9067-782484bebf0a2834.js\",\"4910\",\"static/chunks/4910-00fb342a68dc875b.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"3895\",\"static/chunks/3895-1ab7397e3e21938b.js\",\"7267\",\"static/chunks/7267-f0f5047cdc5c0071.js\",\"5015\",\"static/chunks/5015-e23efc6724184a73.js\",\"1682\",\"static/chun"])</script><script>self.__next_f.push([1,"ks/1682-fe5b6177f2c1a97a.js\",\"9045\",\"static/chunks/9045-278ec3e8b4b3a58f.js\",\"8429\",\"static/chunks/8429-62579fca5f687ae8.js\",\"74\",\"static/chunks/74-c88803b3b013ce58.js\",\"200\",\"static/chunks/200-7e3b6f6e0e7f03c5.js\",\"3626\",\"static/chunks/3626-9337d7c762494d1d.js\",\"210\",\"static/chunks/210-073740ea9519245f.js\",\"7474\",\"static/chunks/7474-0a7b236f9a97fc33.js\",\"5348\",\"static/chunks/5348-c66ef010d86bd2f3.js\",\"3619\",\"static/chunks/3619-6fe66cbf29d0baeb.js\",\"8528\",\"static/chunks/app/(console)/docs/(mdx-pages)/speech-to-text/page-5c9b7aa7f078d443.js\"],\"default\"]\nd:I[26890,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"4913\",\"static/chunks/4913-4ea28f93261ac149.js\",\"2721\",\"static/chunks/2721-386e7e50f093ad1d.js\",\"6689\",\"static/chunks/6689-dd753e9b53422d74.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"9067\",\"static/chunks/9067-782484bebf0a2834.js\",\"4910\",\"static/chunks/4910-00fb342a68dc875b.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"3895\",\"static/chunks/3895-1ab7397e3e21938b.js\",\"7267\",\"static/chunks/7267-f0f5047cdc5c0071.js\",\"5015\",\"static/chunks/5015-e23efc6724184a73.js\",\"1682\",\"static/chunks/1682-fe5b6177f2c1a97a.js\",\"9045\",\"static/chunks/9045-278ec3e8b4b3a58f.js\",\"8429\",\"static/chunks/8429-62579fca5f687ae8.js\",\"74\",\"static/chunks/74-c88803b3b013ce58.js\",\"200\",\"static/chunks/200-7e3b6f6e0e7f03c5.js\",\"3626\",\"static/chunks/3626-9337d7c762494d1d.js\",\"210\",\"static/chunks/210-073740ea9519245f.js\",\"7474\",\"static/chunks/7474-0a7b236f9a97fc33.js\",\"5348\",\"static/chunks/5348-c66ef010d86bd2f3.js\",\"3619\",\"static/chunks/3619-6fe66cbf29d0baeb.js\",\"8528\",\"static/chunks/app/(console)/docs/(mdx-pages)/speech-to-text/page-5c9b7aa7f078d443.js\"],\"LanguageTabs\"]\ne:I[26890,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"4913\",\"static/chunks/4913-4ea28f93261ac149.js\",\"2721\",\"static/chunks/2721-386e7e50f093ad1d.js\",\"6689\",\"static/chunks/6689-dd753e9b53422d74.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"9067\",\"static"])</script><script>self.__next_f.push([1,"/chunks/9067-782484bebf0a2834.js\",\"4910\",\"static/chunks/4910-00fb342a68dc875b.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"3895\",\"static/chunks/3895-1ab7397e3e21938b.js\",\"7267\",\"static/chunks/7267-f0f5047cdc5c0071.js\",\"5015\",\"static/chunks/5015-e23efc6724184a73.js\",\"1682\",\"static/chunks/1682-fe5b6177f2c1a97a.js\",\"9045\",\"static/chunks/9045-278ec3e8b4b3a58f.js\",\"8429\",\"static/chunks/8429-62579fca5f687ae8.js\",\"74\",\"static/chunks/74-c88803b3b013ce58.js\",\"200\",\"static/chunks/200-7e3b6f6e0e7f03c5.js\",\"3626\",\"static/chunks/3626-9337d7c762494d1d.js\",\"210\",\"static/chunks/210-073740ea9519245f.js\",\"7474\",\"static/chunks/7474-0a7b236f9a97fc33.js\",\"5348\",\"static/chunks/5348-c66ef010d86bd2f3.js\",\"3619\",\"static/chunks/3619-6fe66cbf29d0baeb.js\",\"8528\",\"static/chunks/app/(console)/docs/(mdx-pages)/speech-to-text/page-5c9b7aa7f078d443.js\"],\"TabContent\"]\n10:I[94986,[],\"OutletBoundary\"]\n13:I[94986,[],\"ViewportBoundary\"]\n15:I[94986,[],\"MetadataBoundary\"]\n17:I[59607,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"4219\",\"static/chunks/app/global-error-47cc8ff3bbff2b0a.js\"],\"default\"]\n:HL[\"/_next/static/media/17e5ee57c5ca5e5a-s.p.woff2\",\"font\",{\"crossOrigin\":\"\",\"type\":\"font/woff2\"}]\n:HL[\"/_next/static/media/4f05ba3a6752a328-s.p.woff2\",\"font\",{\"crossOrigin\":\"\",\"type\":\"font/woff2\"}]\n:HL[\"/_next/static/media/e4af272ccee01ff0-s.p.woff2\",\"font\",{\"crossOrigin\":\"\",\"type\":\"font/woff2\"}]\n:HL[\"/_next/static/css/1aec9fa0613931f6.css\",\"style\"]\n:HL[\"/_next/static/css/6f67043a32b06372.css\",\"style\"]\n:HL[\"/_next/static/css/d428f878c7dcb717.css\",\"style\"]\n:HL[\"/_next/static/css/2a7ba0e01a4cc002.css\",\"style\"]\n:HL[\"/_next/static/css/b1dbd2d25ec6d91f.css\",\"style\"]\nf:T41b,import os\nimport json\nfrom groq import Groq\n\n# Initialize the Groq client\nclient = Groq()\n\n# Specify the path to the audio file\nfilename = os.path.dirname(__file__) + \"/YOUR_AUDIO.wav\" # Replace with your audio file!\n\n# Open the audio file\nwith open(filename, \"rb\") as file:\n # Create a transcription of the audio file\n transcr"])</script><script>self.__next_f.push([1,"iption = client.audio.transcriptions.create(\n file=file, # Required audio file\n model=\"whisper-large-v3-turbo\", # Required model to use for transcription\n prompt=\"Specify context or spelling\", # Optional\n response_format=\"verbose_json\", # Optional\n timestamp_granularities = [\"word\", \"segment\"], # Optional (must set response_format to \"json\" to use and can specify \"word\", \"segment\" (default), or both)\n language=\"en\", # Optional\n temperature=0.0 # Optional\n )\n # To print only the transcription text, you'd use print(transcription.text) (here we're printing the entire transcription object to access timestamps)\n print(json.dumps(transcription, indent=2, default=str))"])</script><script>self.__next_f.push([1,"0:{\"P\":null,\"b\":\"rQQHN3woVAx2TGQ9RZ28y\",\"p\":\"\",\"c\":[\"\",\"docs\",\"speech-to-text\"],\"i\":false,\"f\":[[[\"\",{\"children\":[\"(console)\",{\"children\":[\"docs\",{\"children\":[\"(mdx-pages)\",{\"children\":[\"speech-to-text\",{\"children\":[\"__PAGE__\",{}]}]}]}]}]},\"$undefined\",\"$undefined\",true],[\"\",[\"$\",\"$1\",\"c\",{\"children\":[[[\"$\",\"link\",\"0\",{\"rel\":\"stylesheet\",\"href\":\"/_next/static/css/1aec9fa0613931f6.css\",\"precedence\":\"next\",\"crossOrigin\":\"$undefined\",\"nonce\":\"$undefined\"}],[\"$\",\"link\",\"1\",{\"rel\":\"stylesheet\",\"href\":\"/_next/static/css/6f67043a32b06372.css\",\"precedence\":\"next\",\"crossOrigin\":\"$undefined\",\"nonce\":\"$undefined\"}],[\"$\",\"link\",\"2\",{\"rel\":\"stylesheet\",\"href\":\"/_next/static/css/d428f878c7dcb717.css\",\"precedence\":\"next\",\"crossOrigin\":\"$undefined\",\"nonce\":\"$undefined\"}]],\"$L2\"]}],{\"children\":[\"(console)\",[\"$\",\"$1\",\"c\",{\"children\":[null,[\"$\",\"$L3\",null,{\"Component\":\"$4\",\"slots\":{\"children\":[\"$\",\"$L5\",null,{\"parallelRouterKey\":\"children\",\"error\":\"$undefined\",\"errorStyles\":\"$undefined\",\"errorScripts\":\"$undefined\",\"template\":[\"$\",\"$L6\",null,{}],\"templateStyles\":\"$undefined\",\"templateScripts\":\"$undefined\",\"notFound\":[[[\"$\",\"title\",null,{\"children\":\"404: This page could not be found.\"}],[\"$\",\"div\",null,{\"style\":{\"fontFamily\":\"system-ui,\\\"Segoe UI\\\",Roboto,Helvetica,Arial,sans-serif,\\\"Apple Color Emoji\\\",\\\"Segoe UI Emoji\\\"\",\"height\":\"100vh\",\"textAlign\":\"center\",\"display\":\"flex\",\"flexDirection\":\"column\",\"alignItems\":\"center\",\"justifyContent\":\"center\"},\"children\":[\"$\",\"div\",null,{\"children\":[[\"$\",\"style\",null,{\"dangerouslySetInnerHTML\":{\"__html\":\"body{color:#000;background:#fff;margin:0}.next-error-h1{border-right:1px solid rgba(0,0,0,.3)}@media (prefers-color-scheme:dark){body{color:#fff;background:#000}.next-error-h1{border-right:1px solid rgba(255,255,255,.3)}}\"}}],[\"$\",\"h1\",null,{\"className\":\"next-error-h1\",\"style\":{\"display\":\"inline-block\",\"margin\":\"0 20px 0 0\",\"padding\":\"0 23px 0 0\",\"fontSize\":24,\"fontWeight\":500,\"verticalAlign\":\"top\",\"lineHeight\":\"49px\"},\"children\":404}],[\"$\",\"div\",null,{\"style\":{\"display\":\"inline-block\"},\"children\":[\"$\",\"h2\",null,{\"style\":{\"fontSize\":14,\"fontWeight\":400,\"lineHeight\":\"49px\",\"margin\":0},\"children\":\"This page could not be found.\"}]}]]}]}]],[]],\"forbidden\":\"$undefined\",\"unauthorized\":\"$undefined\"}]},\"params\":{},\"promise\":\"$@7\"}]]}],{\"children\":[\"docs\",[\"$\",\"$1\",\"c\",{\"children\":[[[\"$\",\"link\",\"0\",{\"rel\":\"stylesheet\",\"href\":\"/_next/static/css/2a7ba0e01a4cc002.css\",\"precedence\":\"next\",\"crossOrigin\":\"$undefined\",\"nonce\":\"$undefined\"}]],\"$L8\"]}],{\"children\":[\"(mdx-pages)\",[\"$\",\"$1\",\"c\",{\"children\":[null,[\"$\",\"div\",null,{\"children\":[[\"$\",\"$L5\",null,{\"parallelRouterKey\":\"children\",\"error\":\"$undefined\",\"errorStyles\":\"$undefined\",\"errorScripts\":\"$undefined\",\"template\":[\"$\",\"$L6\",null,{}],\"templateStyles\":\"$undefined\",\"templateScripts\":\"$undefined\",\"notFound\":\"$undefined\",\"forbidden\":\"$undefined\",\"unauthorized\":\"$undefined\"}],[\"$\",\"$L9\",null,{}]]}]]}],{\"children\":[\"speech-to-text\",[\"$\",\"$1\",\"c\",{\"children\":[null,[\"$\",\"$L5\",null,{\"parallelRouterKey\":\"children\",\"error\":\"$undefined\",\"errorStyles\":\"$undefined\",\"errorScripts\":\"$undefined\",\"template\":[\"$\",\"$L6\",null,{}],\"templateStyles\":\"$undefined\",\"templateScripts\":\"$undefined\",\"notFound\":\"$undefined\",\"forbidden\":\"$undefined\",\"unauthorized\":\"$undefined\"}]]}],{\"children\":[\"__PAGE__\",[\"$\",\"$1\",\"c\",{\"children\":[[[\"$\",\"h2\",null,{\"id\":\"speech-to-text\",\"className\":\"[\u0026:not(:first-child)]:mt-12 mb-3 text-2xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#speech-to-text\",\"className\":\"anchor-link\",\"children\":[\"Speech to Text\"]}]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"Groq API is the fastest speech-to-text solution available, offering OpenAI-compatible endpoints that\\nenable near-instant transcriptions and translations. With Groq API, you can integrate high-quality audio\\nprocessing into your applications at speeds that rival human interaction.\"}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"h-3\"}],\"\\n\",[\"$\",\"h2\",null,{\"id\":\"api-endpoints\",\"className\":\"[\u0026:not(:first-child)]:mt-12 mb-3 text-2xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#api-endpoints\",\"className\":\"anchor-link\",\"children\":[\"API Endpoints\"]}]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"We support two endpoints:\"}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"relative w-full overflow-auto py-3\",\"children\":[\"$\",\"table\",null,{\"ref\":\"$undefined\",\"className\":\"w-full caption-bottom text-sm py-3\",\"children\":[[\"$\",\"thead\",null,{\"ref\":\"$undefined\",\"className\":\"[\u0026_tr]:border-b hover:none\",\"children\":[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Endpoint\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Usage\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"API Endpoint\"}]]}]}],[\"$\",\"tbody\",null,{\"ref\":\"$undefined\",\"className\":\"[border-0\",\"children\":[[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Transcriptions\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Convert audio to text\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"https://api.groq.com/openai/v1/audio/transcriptions\"}]}]]}],[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Translations\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Translate audio to English text\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"https://api.groq.com/openai/v1/audio/translations\"}]}]]}]]}]]}]}],\"\\n\",[\"$\",\"h2\",null,{\"id\":\"supported-models\",\"className\":\"[\u0026:not(:first-child)]:mt-12 mb-3 text-2xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#supported-models\",\"className\":\"anchor-link\",\"children\":[\"Supported Models\"]}]}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"relative w-full overflow-auto py-3\",\"children\":[\"$\",\"table\",null,{\"ref\":\"$undefined\",\"className\":\"w-full caption-bottom text-sm py-3\",\"children\":[[\"$\",\"thead\",null,{\"ref\":\"$undefined\",\"className\":\"[\u0026_tr]:border-b hover:none\",\"children\":[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Model ID\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Model\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Supported Language(s)\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Description\"}]]}]}],[\"$\",\"tbody\",null,{\"ref\":\"$undefined\",\"className\":\"[border-0\",\"children\":[[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"$La\",null,{\"text\":\"whisper-large-v3-turbo\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Whisper Large V3 Turbo\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Multilingual\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"A fine-tuned version of a pruned Whisper Large V3 designed for fast, multilingual transcription tasks.\"}]]}],[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"$La\",null,{\"text\":\"distil-whisper-large-v3-en\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Distil-Whisper English\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"English-only\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"A distilled, or compressed, version of OpenAI's Whisper model, designed to provide faster, lower cost English speech recognition while maintaining comparable accuracy.\"}]]}],[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"$La\",null,{\"text\":\"whisper-large-v3\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Whisper large-v3\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Multilingual\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Provides state-of-the-art performance with high accuracy for multilingual transcription and translation tasks.\"}]]}]]}]]}]}],\"\\n\",[\"$\",\"h2\",null,{\"id\":\"which-whisper-model-should-you-use\",\"className\":\"[\u0026:not(:first-child)]:mt-12 mb-3 text-2xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#which-whisper-model-should-you-use\",\"className\":\"anchor-link\",\"children\":[\"Which Whisper Model Should You Use?\"]}]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"Having more choices is great, but let's try to avoid decision paralysis by breaking down the tradeoffs between models to find the one most suitable for\\nyour applications:\"}],\"\\n\",[\"$\",\"ul\",null,{\"className\":\"list-disc my-1 text-sm\",\"children\":[\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":[\"If your application is error-sensitive and requires multilingual support, use \",[\"$\",\"$La\",null,{\"text\":\"whisper-large-v3\"}],\".\"]}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":[\"If your application is less sensitive to errors and requires English only, use \",[\"$\",\"$La\",null,{\"text\":\"distil-whisper-large-v3-en\"}],\".\"]}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":[\"If your application requires multilingual support and you need the best price for performance, use \",[\"$\",\"$La\",null,{\"text\":\"whisper-large-v3-turbo\"}],\".\"]}],\"\\n\"]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The following table breaks down the metrics for each model.\"}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"relative w-full overflow-auto py-3\",\"children\":[\"$\",\"table\",null,{\"ref\":\"$undefined\",\"className\":\"w-full caption-bottom text-sm py-3\",\"children\":[[\"$\",\"thead\",null,{\"ref\":\"$undefined\",\"className\":\"[\u0026_tr]:border-b hover:none\",\"children\":[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Model\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Cost Per Hour\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Language Support\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Transcription Support\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Translation Support\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Real-time Speed Factor\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Word Error Rate\"}]]}]}],[\"$\",\"tbody\",null,{\"ref\":\"$undefined\",\"className\":\"[border-0\",\"children\":[[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"$La\",null,{\"text\":\"whisper-large-v3\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"$$0.111\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Multilingual\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Yes\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Yes\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"189\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"10.3%\"}]]}],[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"$La\",null,{\"text\":\"whisper-large-v3-turbo\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"$$0.04\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Multilingual\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Yes\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"No\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"216\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"12%\"}]]}],[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"$La\",null,{\"text\":\"distil-whisper-large-v3-en\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"$$0.02\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"English only\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Yes\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"No\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"250\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"13%\"}]]}]]}]]}]}],\"\\n\",[\"$\",\"h2\",null,{\"id\":\"working-with-audio-files\",\"className\":\"[\u0026:not(:first-child)]:mt-12 mb-3 text-2xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#working-with-audio-files\",\"className\":\"anchor-link\",\"children\":[\"Working with Audio Files\"]}]}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"bg-[#F9FAFB] dark:bg-[#2C2F39] rounded my-4 p-[30px] border\",\"children\":[[\"$\",\"h3\",null,{\"className\":\"text-base font-semibold font-montserrat mb-3\",\"children\":\"Audio File Limitations\"}],[\"$\",\"div\",null,{\"className\":\"text-sm font-light\",\"children\":[[\"$\",\"div\",\"Max File Size\",{\"className\":\"flex justify-between py-1\",\"children\":[[\"$\",\"div\",null,{\"className\":\"font-semibold break-words text-right w-[40%] pr-8\",\"children\":\"Max File Size\"}],[\"$\",\"div\",null,{\"className\":\"text-left break-words w-[60%]\",\"children\":[[\"$\",\"p\",\"p-0\",{\"children\":\"25 MB (free tier), 100MB (dev tier)\"}]]}]]}],[\"$\",\"div\",\"Max Attachment File Size\",{\"className\":\"flex justify-between py-1\",\"children\":[[\"$\",\"div\",null,{\"className\":\"font-semibold break-words text-right w-[40%] pr-8\",\"children\":\"Max Attachment File Size\"}],[\"$\",\"div\",null,{\"className\":\"text-left break-words w-[60%]\",\"children\":[[\"$\",\"p\",\"p-0\",{\"children\":[\"25 MB. If you need to process larger files, use the \",[\"$\",\"code\",\"code-0\",{\"children\":\"url\"}],\" parameter to specify a url to the file instead.\"]}]]}]]}],[\"$\",\"div\",\"Minimum File Length\",{\"className\":\"flex justify-between py-1\",\"children\":[[\"$\",\"div\",null,{\"className\":\"font-semibold break-words text-right w-[40%] pr-8\",\"children\":\"Minimum File Length\"}],[\"$\",\"div\",null,{\"className\":\"text-left break-words w-[60%]\",\"children\":[[\"$\",\"p\",\"p-0\",{\"children\":\"0.01 seconds\"}]]}]]}],[\"$\",\"div\",\"Minimum Billed Length\",{\"className\":\"flex justify-between py-1\",\"children\":[[\"$\",\"div\",null,{\"className\":\"font-semibold break-words text-right w-[40%] pr-8\",\"children\":\"Minimum Billed Length\"}],[\"$\",\"div\",null,{\"className\":\"text-left break-words w-[60%]\",\"children\":[[\"$\",\"p\",\"p-0\",{\"children\":\"10 seconds. If you submit a request less than this, you will still be billed for 10 seconds.\"}]]}]]}],[\"$\",\"div\",\"Supported File Types\",{\"className\":\"flex justify-between py-1\",\"children\":[[\"$\",\"div\",null,{\"className\":\"font-semibold break-words text-right w-[40%] pr-8\",\"children\":\"Supported File Types\"}],[\"$\",\"div\",null,{\"className\":\"text-left break-words w-[60%]\",\"children\":[[\"$\",\"p\",\"p-0\",{\"children\":[\"Either a URL or a direct file upload for \",[\"$\",\"code\",\"code-0\",{\"children\":\"flac\"}],\", \",[\"$\",\"code\",\"code-1\",{\"children\":\"mp3\"}],\", \",[\"$\",\"code\",\"code-2\",{\"children\":\"mp4\"}],\", \",[\"$\",\"code\",\"code-3\",{\"children\":\"mpeg\"}],\", \",[\"$\",\"code\",\"code-4\",{\"children\":\"mpga\"}],\", \",[\"$\",\"code\",\"code-5\",{\"children\":\"m4a\"}],\", \",[\"$\",\"code\",\"code-6\",{\"children\":\"ogg\"}],\", \",[\"$\",\"code\",\"code-7\",{\"children\":\"wav\"}],\", \",[\"$\",\"code\",\"code-8\",{\"children\":\"webm\"}]]}]]}]]}],[\"$\",\"div\",\"Single Audio Track\",{\"className\":\"flex justify-between py-1\",\"children\":[[\"$\",\"div\",null,{\"className\":\"font-semibold break-words text-right w-[40%] pr-8\",\"children\":\"Single Audio Track\"}],[\"$\",\"div\",null,{\"className\":\"text-left break-words w-[60%]\",\"children\":[[\"$\",\"p\",\"p-0\",{\"children\":\"Only the first track will be transcribed for files with multiple audio tracks. (e.g. dubbed video)\"}]]}]]}],[\"$\",\"div\",\"Supported Response Formats\",{\"className\":\"flex justify-between py-1\",\"children\":[[\"$\",\"div\",null,{\"className\":\"font-semibold break-words text-right w-[40%] pr-8\",\"children\":\"Supported Response Formats\"}],[\"$\",\"div\",null,{\"className\":\"text-left break-words w-[60%]\",\"children\":[[\"$\",\"p\",\"p-0\",{\"children\":[[\"$\",\"code\",\"code-0\",{\"children\":\"json\"}],\", \",[\"$\",\"code\",\"code-1\",{\"children\":\"verbose_json\"}],\", \",[\"$\",\"code\",\"code-2\",{\"children\":\"text\"}]]}]]}]]}],[\"$\",\"div\",\"Supported Timestamp Granularities\",{\"className\":\"flex justify-between py-1\",\"children\":[[\"$\",\"div\",null,{\"className\":\"font-semibold break-words text-right w-[40%] pr-8\",\"children\":\"Supported Timestamp Granularities\"}],[\"$\",\"div\",null,{\"className\":\"text-left break-words w-[60%]\",\"children\":[[\"$\",\"p\",\"p-0\",{\"children\":[[\"$\",\"code\",\"code-0\",{\"children\":\"segment\"}],\", \",[\"$\",\"code\",\"code-1\",{\"children\":\"word\"}]]}]]}]]}]]}]]}],\"\\n\",[\"$\",\"h3\",null,{\"id\":\"audio-preprocessing\",\"className\":\"mt-8 mb-3 text-xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#audio-preprocessing\",\"className\":\"anchor-link\",\"children\":[\"Audio Preprocessing\"]}]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":[\"Our speech-to-text models will downsample audio to 16KHz mono before transcribing, which is optimal for speech recognition. This preprocessing can be performed client-side if your original file is extremely\\nlarge and you want to make it smaller without a loss in quality (without chunking, Groq API speech-to-text endpoints accept up to 25MB for free tier and 100MB for \",[\"$\",\"$Lb\",null,{\"className\":\"text-primaryaccent hover:underline\",\"href\":\"/settings/billing\",\"prefetch\":true,\"children\":\"dev tier\"}],\"). For lower latency, convert your files to \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"wav\"}],\" format. When reducing file size, we recommend FLAC for lossless compression.\"]}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"h-3\"}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":[\"The following \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"ffmpeg\"}],\" command can be used to reduce file size:\"]}],\"\\n\",[\"$\",\"$Lc\",null,{\"noPadding\":true,\"languageExamples\":[{\"language\":\"shell\",\"example\":\"ffmpeg \\\\\\n -i \u003cyour file\u003e \\\\\\n -ar 16000 \\\\\\n -ac 1 \\\\\\n -map 0:a \\\\\\n -c:a flac \\\\\\n \u003coutput file name\u003e.flac\\n\"}]}],\"\\n\",[\"$\",\"h3\",null,{\"id\":\"working-with-larger-audio-files\",\"className\":\"mt-8 mb-3 text-xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#working-with-larger-audio-files\",\"className\":\"anchor-link\",\"children\":[\"Working with Larger Audio Files\"]}]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"For audio files that exceed our size limits or require more precise control over transcription, we recommend implementing audio chunking. This process involves:\"}],\"\\n\",[\"$\",\"ol\",null,{\"className\":\"list-decimal my-2 text-sm\",\"children\":[\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":\"Breaking the audio into smaller, overlapping segments\"}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":\"Processing each segment independently\"}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":\"Combining the results while handling overlapping\"}],\"\\n\"]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":[\"$\",\"$Lb\",null,{\"className\":\"text-primaryaccent hover:underline\",\"href\":\"https://github.com/groq/groq-api-cookbook/tree/main/tutorials/audio-chunking\",\"prefetch\":true,\"children\":[\"To learn more about this process and get code for your own implementation, see the complete audio chunking tutorial in our Groq API Cookbook. \",[\"$\",\"svg\",null,{\"aria-label\":\"arrow external\",\"role\":\"img\",\"width\":\"11\",\"height\":\"11\",\"viewBox\":\"0 0 11 12\",\"fill\":\"none\",\"xmlns\":\"http://www.w3.org/2000/svg\",\"className\":\"inline ml-1\",\"children\":[[\"$\",\"g\",null,{\"clipPath\":\"url(#clip0_34_663)\",\"children\":[[\"$\",\"path\",null,{\"d\":\"M5.70078 1.80005H1.15078C0.957476 1.80005 0.800781 1.95674 0.800781 2.15005V9.85005C0.800781 10.0434 0.957476 10.2 1.15078 10.2H8.85078C9.04409 10.2 9.20078 10.0434 9.20078 9.85005V5.30005\",\"stroke\":\"#F55036\",\"strokeLinecap\":\"round\",\"strokeLinejoin\":\"round\"}],[\"$\",\"path\",null,{\"d\":\"M8.75951 2.24011L4.30469 6.69493\",\"stroke\":\"#F55036\",\"strokeLinecap\":\"round\",\"strokeLinejoin\":\"round\"}],[\"$\",\"path\",null,{\"d\":\"M9.71952 3.20009L7.79968 1.28025C7.60594 1.08651 7.74315 0.755249 8.01713 0.755249H9.71952C10.0095 0.755249 10.2445 0.990292 10.2445 1.28025V2.98263C10.2445 3.25661 9.91326 3.39383 9.71952 3.20009Z\",\"stroke\":\"#F55036\",\"strokeLinecap\":\"round\",\"strokeLinejoin\":\"round\"}]]}],[\"$\",\"defs\",null,{\"children\":[\"$\",\"clipPath\",null,{\"id\":\"clip0_34_663\",\"children\":[\"$\",\"rect\",null,{\"width\":\"11\",\"height\":\"11\",\"fill\":\"white\"}]}]}]]}]]}]}],\"\\n\",[\"$\",\"h2\",null,{\"id\":\"using-the-api\",\"className\":\"[\u0026:not(:first-child)]:mt-12 mb-3 text-2xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#using-the-api\",\"className\":\"anchor-link\",\"children\":[\"Using the API\"]}]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The following are request parameters you can use in your transcription and translation requests:\"}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"relative w-full overflow-auto py-3\",\"children\":[\"$\",\"table\",null,{\"ref\":\"$undefined\",\"className\":\"w-full caption-bottom text-sm py-3\",\"children\":[[\"$\",\"thead\",null,{\"ref\":\"$undefined\",\"className\":\"[\u0026_tr]:border-b hover:none\",\"children\":[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Parameter\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Type\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Default\"}],[\"$\",\"th\",null,{\"ref\":\"$undefined\",\"className\":\"h-12 py-3 text-left align-middle font-medium uppercase tracking-wider [\u0026:has([role=checkbox])]:pr-0 dark:text-gray-400 text-[10px] text-muted-foreground pr-6\",\"children\":\"Description\"}]]}]}],[\"$\",\"tbody\",null,{\"ref\":\"$undefined\",\"className\":\"[border-0\",\"children\":[[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"file\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"string\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"Required unless using \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"url\"}],\" instead\"]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"The audio file object for direct upload to translate/transcribe.\"}]]}],[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"url\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"string\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"Required unless using \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"file\"}],\" instead\"]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"The audio URL to translate/transcribe (supports Base64URL).\"}]]}],[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"language\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"string\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Optional\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"The language of the input audio. Supplying the input language in ISO-639-1 (i.e. \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"en, \"}],\"tr`) format will improve accuracy and latency.\",[\"$\",\"br\",null,{}],[\"$\",\"br\",null,{}],\"The translations endpoint only supports 'en' as a parameter option.\"]}]]}],[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"model\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"string\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Required\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"ID of the model to use.\"}]]}],[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"prompt\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"string\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Optional\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"Prompt to guide the model's style or specify how to spell unfamiliar words. (limited to 224 tokens)\"}]]}],[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"response_format\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"string\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"json\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"Define the output response format.\",[\"$\",\"br\",null,{}],[\"$\",\"br\",null,{}],\"Set to \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"verbose_json\"}],\" to receive timestamps for audio segments.\",[\"$\",\"br\",null,{}],[\"$\",\"br\",null,{}],\"Set to \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"text\"}],\" to return a text response.\"]}]]}],[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"temperature\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"float\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"0\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"The temperature between 0 and 1. For translations and transcriptions, we recommend the default value of 0.\"}]]}],[\"$\",\"tr\",null,{\"ref\":\"$undefined\",\"className\":\"border-b border-nav transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted\",\"children\":[[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"timestamp_granularities[]\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"array\"}]}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":\"segment\"}],[\"$\",\"td\",null,{\"ref\":\"$undefined\",\"className\":\"py-2 align-middle [\u0026:has([role=checkbox])]:pr-0 pr-6\",\"children\":[\"The timestamp granularities to populate for this transcription. \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"response_format\"}],\" must be set \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"verbose_json\"}],\" to use timestamp granularities.\",[\"$\",\"br\",null,{}],[\"$\",\"br\",null,{}],\"Either or both of \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"word\"}],\" and \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"segment\"}],\" are supported. \",[\"$\",\"br\",null,{}],[\"$\",\"br\",null,{}],[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"segment\"}],\" returns full metadata and \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"word\"}],\" returns only word, start, and end timestamps. To get both word-level timestamps and full segment metadata, include both values in the array.\"]}]]}]]}]]}]}],\"\\n\",[\"$\",\"h3\",null,{\"id\":\"example-usage-of-transcription-endpoint\",\"className\":\"mt-8 mb-3 text-xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#example-usage-of-transcription-endpoint\",\"className\":\"anchor-link\",\"children\":[\"Example Usage of Transcription Endpoint\"]}]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The transcription endpoint allows you to transcribe spoken words in audio or video files.\"}],\"\\n\",[\"$\",\"$Ld\",null,{\"selectedLanguages\":[\"python\",\"javascript\",\"curl\"],\"className\":\"py-4 gap-y-3\",\"children\":[[\"$\",\"$Le\",null,{\"className\":\"python\",\"children\":[[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The Groq SDK package can be installed using the following command:\"}],[\"$\",\"$Lc\",null,{\"languageExamples\":[{\"language\":\"shell\",\"example\":\"pip install groq\"}]}],[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The following code snippet demonstrates how to use Groq API to transcribe an audio file in Python:\"}],[\"$\",\"$Lc\",null,{\"languageExamples\":[{\"language\":\"py\",\"example\":\"$f\"}]}]]}],[\"$\",\"$Le\",null,{\"className\":\"javascript\",\"children\":[[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The Groq SDK package can be installed using the following command:\"}],[\"$\",\"$Lc\",null,{\"languageExamples\":[{\"language\":\"shell\",\"example\":\"npm install --save groq-sdk\"}]}],[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The following code snippet demonstrates how to use Groq API to transcribe an audio file in JavaScript:\"}],[\"$\",\"$Lc\",null,{\"languageExamples\":[{\"language\":\"js\",\"example\":\"import fs from \\\"fs\\\";\\nimport Groq from \\\"groq-sdk\\\";\\n\\n// Initialize the Groq client\\nconst groq = new Groq();\\n\\nasync function main() {\\n // Create a transcription job\\n const transcription = await groq.audio.transcriptions.create({\\n file: fs.createReadStream(\\\"YOUR_AUDIO.wav\\\"), // Required path to audio file - replace with your audio file!\\n model: \\\"whisper-large-v3-turbo\\\", // Required model to use for transcription\\n prompt: \\\"Specify context or spelling\\\", // Optional\\n response_format: \\\"verbose_json\\\", // Optional\\n timestamp_granularities: [\\\"word\\\", \\\"segment\\\"], // Optional (must set response_format to \\\"json\\\" to use and can specify \\\"word\\\", \\\"segment\\\" (default), or both)\\n language: \\\"en\\\", // Optional\\n temperature: 0.0, // Optional\\n });\\n // To print only the transcription text, you'd use console.log(transcription.text); (here we're printing the entire transcription object to access timestamps)\\n console.log(JSON.stringify(transcription, null, 2));\\n}\\nmain();\"}]}]]}],[\"$\",\"$Le\",null,{\"className\":\"curl\",\"children\":[[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The following is an example cURL request:\"}],[\"$\",\"$Lc\",null,{\"languageExamples\":[{\"language\":\"shell\",\"example\":\"curl https://api.groq.com/openai/v1/audio/transcriptions \\\\\\n -H \\\"Authorization: bearer ${GROQ_API_KEY}\\\" \\\\\\n -F \\\"file=@./sample_audio.m4a\\\" \\\\\\n -F model=whisper-large-v3-turbo \\\\\\n -F temperature=0 \\\\\\n -F response_format=verbose_json \\\\\\n -F timestamp_granularities=[\\\"word\\\"] \\\\\\n -F language=en\"}]}],[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The following is an example response:\"}],[\"$\",\"$Lc\",null,{\"noPadding\":true,\"languageExamples\":[{\"language\":\"json\",\"example\":\"{\\n \\\"text\\\": \\\"Your transcribed text appears here...\\\",\\n \\\"x_groq\\\": {\\n \\\"id\\\": \\\"req_unique_id\\\"\\n }\\n}\\n\"}]}]]}]]}],\"\\n\",[\"$\",\"h3\",null,{\"id\":\"example-usage-of-translation-endpoint\",\"className\":\"mt-8 mb-3 text-xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#example-usage-of-translation-endpoint\",\"className\":\"anchor-link\",\"children\":[\"Example Usage of Translation Endpoint\"]}]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The translation endpoint allows you to translate spoken words in audio or video files to English.\"}],\"\\n\",[\"$\",\"$Ld\",null,{\"selectedLanguages\":[\"python\",\"javascript\",\"curl\"],\"className\":\"py-4\",\"children\":[[\"$\",\"$Le\",null,{\"className\":\"python\",\"children\":[[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The Groq SDK package can be installed using the following command:\"}],[\"$\",\"$Lc\",null,{\"languageExamples\":[{\"language\":\"shell\",\"example\":\"pip install groq\"}]}],[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The following code snippet demonstrates how to use Groq API to translate an audio file in Python:\"}],[\"$\",\"$Lc\",null,{\"languageExamples\":[{\"language\":\"py\",\"example\":\"import os\\nfrom groq import Groq\\n\\n# Initialize the Groq client\\nclient = Groq()\\n\\n# Specify the path to the audio file\\nfilename = os.path.dirname(__file__) + \\\"/sample_audio.m4a\\\" # Replace with your audio file!\\n\\n# Open the audio file\\nwith open(filename, \\\"rb\\\") as file:\\n # Create a translation of the audio file\\n translation = client.audio.translations.create(\\n file=(filename, file.read()), # Required audio file\\n model=\\\"whisper-large-v3\\\", # Required model to use for translation\\n prompt=\\\"Specify context or spelling\\\", # Optional\\n language=\\\"en\\\", # Optional ('en' only)\\n response_format=\\\"json\\\", # Optional\\n temperature=0.0 # Optional\\n )\\n # Print the translation text\\n print(translation.text)\"}]}]]}],[\"$\",\"$Le\",null,{\"className\":\"javascript\",\"children\":[[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The Groq SDK package can be installed using the following command:\"}],[\"$\",\"$Lc\",null,{\"languageExamples\":[{\"language\":\"shell\",\"example\":\"npm install --save groq-sdk\"}]}],[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The following code snippet demonstrates how to use Groq API to translate an audio file in JavaScript:\"}],[\"$\",\"$Lc\",null,{\"languageExamples\":[{\"language\":\"js\",\"example\":\"import fs from \\\"fs\\\";\\nimport Groq from \\\"groq-sdk\\\";\\n\\n// Initialize the Groq client\\nconst groq = new Groq();\\nasync function main() {\\n // Create a translation job\\n const translation = await groq.audio.translations.create({\\n file: fs.createReadStream(\\\"sample_audio.m4a\\\"), // Required path to audio file - replace with your audio file!\\n model: \\\"whisper-large-v3\\\", // Required model to use for translation\\n prompt: \\\"Specify context or spelling\\\", // Optional\\n language: \\\"en\\\", // Optional ('en' only)\\n response_format: \\\"json\\\", // Optional\\n temperature: 0.0, // Optional\\n });\\n // Log the transcribed text\\n console.log(translation.text);\\n}\\nmain();\"}]}]]}],[\"$\",\"$Le\",null,{\"className\":\"curl\",\"children\":[[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The following is an example cURL request:\"}],[\"$\",\"$Lc\",null,{\"languageExamples\":[{\"language\":\"shell\",\"example\":\"curl https://api.groq.com/openai/v1/audio/translations \\\\\\n -H \\\"Authorization: bearer ${GROQ_API_KEY}\\\" \\\\\\n -F \\\"file=@./sample_audio.m4a\\\" \\\\\\n -F model=whisper-large-v3 \\\\\\n -F prompt=\\\"Specify context or spelling\\\" \\\\\\n -F language=\\\"en\\\" \\\\\\n -F temperature=0 \\\\\\n -F response_format=json\"}]}],[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The following is an example response:\"}],[\"$\",\"$Lc\",null,{\"noPadding\":true,\"languageExamples\":[{\"language\":\"json\",\"example\":\"{\\n \\\"text\\\": \\\"Your translated text appears here...\\\",\\n \\\"x_groq\\\": {\\n \\\"id\\\": \\\"req_unique_id\\\"\\n }\\n}\\n\"}]}]]}]]}],\"\\n\",[\"$\",\"h2\",null,{\"id\":\"understanding-metadata-fields\",\"className\":\"[\u0026:not(:first-child)]:mt-12 mb-3 text-2xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#understanding-metadata-fields\",\"className\":\"anchor-link\",\"children\":[\"Understanding Metadata Fields\"]}]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":[\"When working with Groq API, setting \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"response_format\"}],\" to \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"verbose_json\"}],\" outputs each segment of transcribed text with valuable metadata that helps us understand the quality and characteristics of our\\ntranscription, including \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"avg_logprob\"}],\", \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"compression_ratio\"}],\", and \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"no_speech_prob\"}],\".\"]}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"h-3\"}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"This information can help us with debugging any transcription issues. Let's examine what this metadata tells us using a real\\nexample:\"}],\"\\n\",[\"$\",\"$Lc\",null,{\"noPadding\":true,\"languageExamples\":[{\"language\":\"json\",\"example\":\"{\\n \\\"id\\\": 8,\\n \\\"seek\\\": 3000,\\n \\\"start\\\": 43.92,\\n \\\"end\\\": 50.16,\\n \\\"text\\\": \\\" document that the functional specification that you started to read through that isn't just the\\\",\\n \\\"tokens\\\": [51061, 4166, 300, 264, 11745, 31256],\\n \\\"temperature\\\": 0,\\n \\\"avg_logprob\\\": -0.097569615,\\n \\\"compression_ratio\\\": 1.6637554,\\n \\\"no_speech_prob\\\": 0.012814695\\n}\\n\"}]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"As shown in the above example, we receive timing information as well as quality indicators. Let's gain a better understanding of what each field means:\"}],\"\\n\",[\"$\",\"ul\",null,{\"className\":\"list-disc my-1 text-sm\",\"children\":[\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":[[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"id:8\"}],\": The 9th segment in the transcription (counting begins at 0)\"]}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":[[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"seek\"}],\": Indicates where in the audio file this segment begins (3000 in this case)\"]}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":[[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"start\"}],\" and \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"end\"}],\" timestamps: Tell us exactly when this segment occurs in the audio (43.92 to 50.16 seconds in our example)\"]}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":[[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"avg_logprob\"}],\" (Average Log Probability): -0.097569615 in our example indicates very high confidence. Values closer to 0 suggest better confidence, while more negative values (like -0.5 or lower) might\\nindicate transcription issues.\"]}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":[[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"no_speech_prob\"}],\" (No Speech Probability): 0.0.012814695 is very low, suggesting this is definitely speech. Higher values (closer to 1) would indicate potential silence or non-speech audio.\"]}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":[[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"compression_ratio\"}],\": 1.6637554 is a healthy value, indicating normal speech patterns. Unusual values (very high or low) might suggest issues with speech clarity or word boundaries.\"]}],\"\\n\"]}],\"\\n\",[\"$\",\"h3\",null,{\"id\":\"using-metadata-for-debugging\",\"className\":\"mt-8 mb-3 text-xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#using-metadata-for-debugging\",\"className\":\"anchor-link\",\"children\":[\"Using Metadata for Debugging\"]}]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"When troubleshooting transcription issues, look for these patterns:\"}],\"\\n\",[\"$\",\"ul\",null,{\"className\":\"list-disc my-1 text-sm\",\"children\":[\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":[\"Low Confidence Sections: If \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"avg_logprob\"}],\" drops significantly (becomes more negative), check for background noise, multiple speakers talking simultaneously, unclear pronunciation, and strong accents.\\nConsider cleaning up the audio in these sections or adjusting chunk sizes around problematic chunk boundaries.\"]}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":[\"Non-Speech Detection: High \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"no_speech_prob\"}],\" values might indicate silence periods that could be trimmed, background music or noise, or non-verbal sounds being misinterpreted as speech. Consider noise\\nreduction when preprocessing.\"]}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":[\"Unusual Speech Patterns: Unexpected \",[\"$\",\"code\",null,{\"className\":\"bg-gray-100 dark:bg-gray-800 py-0.5 px-[0.5em] rounded-[4px]\",\"children\":\"compression_ratio\"}],\" values can reveal stuttering or word repetition, speaker talking unusually fast or slow, or audio quality issues affecting word separation.\"]}],\"\\n\"]}],\"\\n\",[\"$\",\"h3\",null,{\"id\":\"quality-thresholds-and-regular-monitoring\",\"className\":\"mt-8 mb-3 text-xl w-fit font-semibold font-montserrat hover:underline\",\"children\":[\"$\",\"a\",null,{\"href\":\"#quality-thresholds-and-regular-monitoring\",\"className\":\"anchor-link\",\"children\":[\"Quality Thresholds and Regular Monitoring\"]}]}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"We recommend setting acceptable ranges for each metadata value we reviewed above and flagging segments that fall outside these ranges to be able to identify and adjust preprocessing or chunking strategies for\\nflagged sections.\"}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"h-3\"}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"By understanding and monitoring these metadata values, you can significantly improve your transcription quality and quickly identify potential issues in your audio processing pipeline.\"}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"h-3\"}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"h-3\"}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"bg-[#F9FAFB] dark:bg-[#37393D] rounded-[38px] p-[26px] border-[12px]\",\"children\":[[\"$\",\"h3\",null,{\"id\":\"prompting-guidelines\",\"className\":\"text-base font-semibold font-montserrat mb-3\",\"children\":[\"$\",\"a\",null,{\"href\":\"#prompting-guidelines\",\"className\":\"anchor-link\",\"children\":\"Prompting Guidelines\"}]}],[\"$\",\"div\",null,{\"className\":\"text-sm font-light\",\"children\":[[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"The prompt parameter (max 224 tokens) helps provide context and maintain a consistent output style.\\nUnlike chat completion prompts, these prompts only guide style and context, not specific actions.\"}],[\"$\",\"div\",null,{\"className\":\"font-montserrat font-semibold pb-3 pt-6\",\"children\":\"Best Practices\"}],[\"$\",\"ul\",null,{\"className\":\"list-disc my-1 text-sm\",\"children\":[\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":\"Provide relevant context about the audio content, such as the type of conversation, topic, or\\nspeakers involved.\"}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":\"Use the same language as the language of the audio file.\"}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":\"Steer the model's output by denoting proper spellings or emulate a specific writing style or tone.\"}],\"\\n\",[\"$\",\"li\",null,{\"className\":\"ml-6 my-1.5 text-sm\",\"children\":\"Keep the prompt concise and focused on stylistic guidance.\"}],\"\\n\"]}]]}]]}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"h-3\"}],\"\\n\",[\"$\",\"div\",null,{\"className\":\"h-3\"}],\"\\n\",[\"$\",\"p\",null,{\"className\":\"text-sm\",\"children\":\"We can't wait to see what you build! 🚀\"}]],\"$undefined\",[[\"$\",\"link\",\"0\",{\"rel\":\"stylesheet\",\"href\":\"/_next/static/css/b1dbd2d25ec6d91f.css\",\"precedence\":\"next\",\"crossOrigin\":\"$undefined\",\"nonce\":\"$undefined\"}]],[\"$\",\"$L10\",null,{\"children\":[\"$L11\",\"$L12\",null]}]]}],{},null,false]},null,false]},null,false]},null,false]},null,false]},null,false],[\"$\",\"$1\",\"h\",{\"children\":[null,[\"$\",\"$1\",\"UpNizxIg_tl2CMxe1WuYs\",{\"children\":[[\"$\",\"$L13\",null,{\"children\":\"$L14\"}],[\"$\",\"meta\",null,{\"name\":\"next-size-adjust\",\"content\":\"\"}]]}],[\"$\",\"$L15\",null,{\"children\":\"$L16\"}]]}],false]],\"m\":\"$undefined\",\"G\":[\"$17\",[]],\"s\":false,\"S\":true}\n"])</script><script>self.__next_f.push([1,"1a:I[45201,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"1653\",\"static/chunks/34afc933-bddb7495ae667dbd.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"7177\",\"static/chunks/app/layout-433e31a816c11c18.js\"],\"GoogleAnalytics\"]\n1b:I[10817,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"1653\",\"static/chunks/34afc933-bddb7495ae667dbd.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"7177\",\"static/chunks/app/layout-433e31a816c11c18.js\"],\"GoogleTagManager\"]\n1c:I[66347,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"1653\",\"static/chunks/34afc933-bddb7495ae667dbd.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"7177\",\"static/chunks/app/layout-433e31a816c11c18.js\"],\"SpeedInsights\"]\n7:{}\n18:T1345,"])</script><script>self.__next_f.push([1,"/* For our datagrail consent banner */\n/* https://docs.datagrail.io/docs/consent/banner/css-customization/ */\n\n:host(.dg-consent-banner) {\n /* Fonts - matching Groq Console system */\n --dg-primary-font: Inter, -apple-system, BlinkMacSystemFont, \"Segoe UI\",\n Roboto, \"Helvetica Neue\", Arial, sans-serif;\n --dg-secondary-font: Montserrat, -apple-system, BlinkMacSystemFont, \"Segoe UI\",\n Roboto, \"Helvetica Neue\", Arial, sans-serif;\n\n /* General banner styling */\n --dg-consent-background-color: rgb(255, 255, 255);\n --dg-consent-background-border: rgb(231, 229, 228);\n --consent-border-radius: 12px;\n\n /* Body text styling */\n --dg-body-font-size: 14px;\n --dg-body-font-weight: 400;\n --dg-body-font-color: rgb(118, 111, 107);\n --dg-body-line-height: 1.5;\n\n /* Heading styling */\n --dg-heading-font-size: 18px;\n --dg-heading-font-weight: 600;\n --dg-heading-font-color: rgb(12, 10, 9);\n --dg-heading-line-height: 1.4;\n\n /* Title styling */\n --dg-title-font-size: 16px;\n --dg-title-font-weight: 500;\n --dg-title-font-color: rgb(30, 30, 30);\n --dg-title-line-height: 1.4;\n\n /* Button styling */\n --dg-button-border: rgb(231, 229, 228) 1px solid;\n --dg-button-primary-background: rgb(30, 30, 30);\n --dg-button-primary-color: rgb(248, 248, 247);\n --dg-button-secondary-background: rgb(243, 243, 242);\n --dg-button-secondary-color: rgb(28, 25, 23);\n\n /* Category styling */\n --dg-policy-option-heading-size: 15px;\n --dg-policy-option-heading-weight: 500;\n --dg-policy-option-heading-color: rgb(30, 30, 30);\n --dg-policy-option-heading-enabled-color: rgb(245, 80, 54);\n --dg-policy-option-chevron-size: 16;\n\n /* Category description */\n --dg-policy-option-description-font-size: 13px;\n --dg-policy-option-description-font-weight: 400;\n --dg-policy-option-description-font-color: rgb(118, 111, 107);\n\n /* Essential categories */\n --dg-policy-option-essential-label-font-size: 12px;\n --dg-policy-option-essential-label-font-weight: 500;\n --dg-policy-option-essential-label-font-color: rgb(118, 111, 107);\n\n /* Slider styling - inspired by switch component */\n --dg-slider-primary: rgb(231, 229, 228);\n --dg-slider-secondary: rgb(255, 255, 255);\n\n --dg-slider-enabled-primary: rgb(30, 30, 30);\n --dg-slider-enabled-secondary: rgb(255, 255, 255);\n\n /* For Enabled Categories */\n --dg-policy-option-heading-enabled-color: rgb(245, 80, 54);\n}\n\n:host(.dg-consent-banner) strong {\n font-weight: 500;\n}\n\n/* Slider styling for checked enabled categories */\n:host(.dg-consent-banner)\n input[type=\"checkbox\"]:not(:disabled):checked\n + label\n .dg-slider {\n background: rgb(30, 30, 30) !important;\n}\n\n/* Advanced button styling to match Groq Console */\n:host(.dg-consent-banner) .dg-button {\n border-radius: 8px !important;\n padding: 8px 16px !important;\n font-weight: 500 !important;\n font-size: 14px !important;\n transition: all 0.2s ease !important;\n}\n\n:host(.dg-consent-banner) .dg-button.accept_all,\n:host(.dg-consent-banner) .dg-button.accept_some {\n background: rgb(30, 30, 30) !important;\n color: rgb(248, 248, 247) !important;\n /* border: 1px solid rgb(245, 80, 54) !important; */\n}\n\n:host(.dg-consent-banner) .dg-button.accept_all:hover,\n:host(.dg-consent-banner) .dg-button.accept_some:hover {\n background: oklch(44.6% 0.03 256.802) !important;\n /* border-color: rgb(220, 70, 48) !important; */\n}\n\n:host(.dg-consent-banner) .dg-button.reject_all,\n:host(.dg-consent-banner) .dg-button.custom {\n background: rgb(243, 243, 242) !important;\n color: rgb(28, 25, 23) !important;\n border: 1px solid rgb(231, 229, 228) !important;\n}\n\n:host(.dg-consent-banner) .dg-button.reject_all:hover,\n:host(.dg-consent-banner) .dg-button.custom:hover {\n background: rgb(231, 229, 228) !important;\n}\n\n/* Link styling to match Groq Console */\n:host(.dg-consent-banner) .dg-link {\n color: rgb(245, 80, 54) !important;\n text-decoration: none !important;\n font-weight: 500 !important;\n}\n\n:host(.dg-consent-banner) .dg-link:hover {\n text-decoration: underline !important;\n}\n\n:host(.dg-consent-banner) .dg-main-content-policy-option-description p {\n margin-top: 0 !important;\n margin-bottom: 16px;\n}\n\n/* Dark mode support */\n:host(.dg-consent-banner) .dark {\n --dg-consent-background-color: rgb(18, 20, 24);\n --dg-consent-background-border: rgba(153, 153, 153, 0.161);\n --dg-body-font-color: rgb(165, 160, 156);\n --dg-heading-font-color: rgb(248, 248, 247);\n --dg-title-font-color: rgb(248, 248, 247);\n --dg-policy-option-heading-color: rgb(248, 248, 247);\n --dg-button-secondary-background: rgb(38, 38, 38);\n --dg-button-secondary-color: rgb(248, 248, 247);\n --dg-slider-primary: rgba(153, 153, 153, 0.35);\n --dg-slider-background: rgb(107, 114, 128);\n}\n\n/* Overall banner container styling */\n:host(.dg-consent-banner) .dg-app {\n box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -2px\n rgba(0, 0, 0, 0.1) !important;\n border: 1px solid rgb(231, 229, 228) !important;\n}\n"])</script><script>self.__next_f.push([1,"2:[\"$\",\"html\",null,{\"lang\":\"en\",\"className\":\"__variable_4bc053 __variable_e8ce0c\",\"suppressHydrationWarning\":true,\"children\":[[\"$\",\"head\",null,{\"children\":[\"$\",\"style\",null,{\"id\":\"dg-consent-custom-style\",\"dangerouslySetInnerHTML\":{\"__html\":\"$18\"}}]}],[\"$\",\"script\",null,{\"async\":true,\"src\":\"/g.js\"}],[\"$\",\"script\",null,{\"async\":true,\"src\":\"https://js.stripe.com/v3/\"}],[\"$\",\"body\",null,{\"className\":\"font-inter\",\"children\":[\"$L19\",[\"$\",\"$L1a\",null,{\"gaId\":\"G-CQ9K0VPEEQ\"}],[\"$\",\"$L1b\",null,{\"gtmId\":\"GTM-WWK828JN\"}],[\"$\",\"$L1c\",null,{\"sampleRate\":0.01}]]}]]}]\n"])</script><script>self.__next_f.push([1,"1d:I[95101,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"1653\",\"static/chunks/34afc933-bddb7495ae667dbd.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"7177\",\"static/chunks/app/layout-433e31a816c11c18.js\"],\"PostHogClientProvider\"]\n1e:I[60854,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"1653\",\"static/chunks/34afc933-bddb7495ae667dbd.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"7177\",\"static/chunks/app/layout-433e31a816c11c18.js\"],\"ClientProviders\"]\n1f:I[48757,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"1653\",\"static/chunks/34afc933-bddb7495ae667dbd.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"7177\",\"static/chunks/app/layout-433e31a816c11c18.js\"],\"ModalProvider\"]\n19:[\"$\",\"$L1d\",null,{\"flags\":{},\"distinctID\":\"$undefined\",\"children\":[\"$\",\"$L1e\",null,{\"layoutPreferences\":{},\"children\":[\"$\",\"$L1f\",null,{\"children\":[\"$\",\"$L5\",null,{\"parallelRouterKey\":\"children\",\"error\":\"$undefined\",\"errorStyles\":\"$undefined\",\"errorScripts\":\"$undefined\",\"template\":[\"$\",\"$L6\",null,{}],\"templateStyles\":\"$undefined\",\"templateScripts\":\"$undefined\",\"notFound\":[[[\"$\",\"title\",null,{\"children\":\"404: This page could not be found.\"}],[\"$\",\"div\",null,{\"style\":\"$0:f:0:1:2:children:1:props:children:1:props:slots:children:props:notFound:0:1:props:style\",\"children\":[\"$\",\"div\",null,{\"children\":[[\"$\",\"style\",null,{\"dangerouslySetInnerHTML\":{\"__html\":\"body{color:#000;background:#fff;margin:0}.next-error-h1{border-right:1px solid rgba(0,0,0,.3)}@media (prefers-color-scheme:dark){body{color:#fff;background:#000}.next-error-h1{border-right:1px solid rgba(255,255,255,.3)}}\"}}],[\"$\",\"h1\",null,{\"className\":\"next-error-h1\",\"style\":\"$0:f:0:1:2:children:1:props:children:1:props:slots:children:props:notFound:0:1:props:children:props:chil"])</script><script>self.__next_f.push([1,"dren:1:props:style\",\"children\":404}],[\"$\",\"div\",null,{\"style\":\"$0:f:0:1:2:children:1:props:children:1:props:slots:children:props:notFound:0:1:props:children:props:children:2:props:style\",\"children\":[\"$\",\"h2\",null,{\"style\":\"$0:f:0:1:2:children:1:props:children:1:props:slots:children:props:notFound:0:1:props:children:props:children:2:props:children:props:style\",\"children\":\"This page could not be found.\"}]}]]}]}]],[]],\"forbidden\":\"$undefined\",\"unauthorized\":\"$undefined\"}]}]}]}]\n"])</script><script>self.__next_f.push([1,"14:[[\"$\",\"meta\",\"0\",{\"charSet\":\"utf-8\"}],[\"$\",\"meta\",\"1\",{\"name\":\"viewport\",\"content\":\"width=device-width, initial-scale=1, maximum-scale=1\"}]]\n11:null\n"])</script><script>self.__next_f.push([1,"12:null\n16:[[\"$\",\"title\",\"0\",{\"children\":\"Speech to Text - GroqDocs\"}],[\"$\",\"meta\",\"1\",{\"name\":\"description\",\"content\":\"Integrate Groq's fast speech-to-text API for instant audio transcription and translation in your applications.\"}],[\"$\",\"meta\",\"2\",{\"property\":\"og:title\",\"content\":\"GroqDocs - Build Fast\"}],[\"$\",\"meta\",\"3\",{\"property\":\"og:description\",\"content\":\"Documentation for Groq products and APIs.\"}],[\"$\",\"meta\",\"4\",{\"property\":\"og:url\",\"content\":\"https://console.groq.com\"}],[\"$\",\"meta\",\"5\",{\"property\":\"og:image\",\"content\":\"https://console.groq.com/og_cloudv5.jpg\"}],[\"$\",\"meta\",\"6\",{\"property\":\"og:type\",\"content\":\"website\"}],[\"$\",\"meta\",\"7\",{\"name\":\"twitter:card\",\"content\":\"summary_large_image\"}],[\"$\",\"meta\",\"8\",{\"name\":\"twitter:title\",\"content\":\"GroqDocs - Build Fast\"}],[\"$\",\"meta\",\"9\",{\"name\":\"twitter:description\",\"content\":\"Documentation for Groq products and APIs.\"}],[\"$\",\"meta\",\"10\",{\"name\":\"twitter:image\",\"content\":\"https://console.groq.com/og_cloudv5.jpg\"}],[\"$\",\"link\",\"11\",{\"rel\":\"icon\",\"href\":\"/favicon.ico\",\"type\":\"image/x-icon\",\"sizes\":\"32x32\"}]]\n"])</script><script>self.__next_f.push([1,"20:I[654,[\"800\",\"static/chunks/01df44d8-7ed632189310937d.js\",\"6268\",\"static/chunks/6268-fc9efab2e6621483.js\",\"4913\",\"static/chunks/4913-4ea28f93261ac149.js\",\"5687\",\"static/chunks/5687-e8f7c0a4850cf3f5.js\",\"6812\",\"static/chunks/6812-557289db23421342.js\",\"7267\",\"static/chunks/7267-f0f5047cdc5c0071.js\",\"1682\",\"static/chunks/1682-fe5b6177f2c1a97a.js\",\"7711\",\"static/chunks/7711-106bc51b6964ef76.js\",\"210\",\"static/chunks/210-073740ea9519245f.js\",\"4997\",\"static/chunks/4997-f654d8eb60de165a.js\",\"9382\",\"static/chunks/app/(console)/docs/layout-62928ffb786bbb31.js\"],\"default\"]\n21:Tfac,"])</script><script>self.__next_f.push([1,"{\n \"id\": \"chatcmpl-f51b2cd2-bef7-417e-964e-a08f0b513c22\",\n \"object\": \"chat.completion\",\n \"created\": 1730241104,\n \"model\": \"llama3-8b-8192\",\n \"choices\": [\n {\n \"index\": 0,\n \"message\": {\n \"role\": \"assistant\",\n \"content\": \"Fast language models have gained significant attention in recent years due to their ability to process and generate human-like text quickly and efficiently. The importance of fast language models can be understood from their potential applications and benefits:\\n\\n1. **Real-time Chatbots and Conversational Interfaces**: Fast language models enable the development of chatbots and conversational interfaces that can respond promptly to user queries, making them more engaging and useful.\\n2. **Sentiment Analysis and Opinion Mining**: Fast language models can quickly analyze text data to identify sentiments, opinions, and emotions, allowing for improved customer service, market research, and opinion mining.\\n3. **Language Translation and Localization**: Fast language models can quickly translate text between languages, facilitating global communication and enabling businesses to reach a broader audience.\\n4. **Text Summarization and Generation**: Fast language models can summarize long documents or even generate new text on a given topic, improving information retrieval and processing efficiency.\\n5. **Named Entity Recognition and Information Extraction**: Fast language models can rapidly recognize and extract specific entities, such as names, locations, and organizations, from unstructured text data.\\n6. **Recommendation Systems**: Fast language models can analyze large amounts of text data to personalize product recommendations, improve customer experience, and increase sales.\\n7. **Content Generation for Social Media**: Fast language models can quickly generate engaging content for social media platforms, helping businesses maintain a consistent online presence and increasing their online visibility.\\n8. **Sentiment Analysis for Stock Market Analysis**: Fast language models can quickly analyze social media posts, news articles, and other text data to identify sentiment trends, enabling financial analysts to make more informed investment decisions.\\n9. **Language Learning and Education**: Fast language models can provide instant feedback and adaptive language learning, making language education more effective and engaging.\\n10. **Domain-Specific Knowledge Extraction**: Fast language models can quickly extract relevant information from vast amounts of text data, enabling domain experts to focus on high-level decision-making rather than manual information gathering.\\n\\nThe benefits of fast language models include:\\n\\n* **Increased Efficiency**: Fast language models can process large amounts of text data quickly, reducing the time and effort required for tasks such as sentiment analysis, entity recognition, and text summarization.\\n* **Improved Accuracy**: Fast language models can analyze and learn from large datasets, leading to more accurate results and more informed decision-making.\\n* **Enhanced User Experience**: Fast language models can enable real-time interactions, personalized recommendations, and timely responses, improving the overall user experience.\\n* **Cost Savings**: Fast language models can automate many tasks, reducing the need for manual labor and minimizing costs associated with data processing and analysis.\\n\\nIn summary, fast language models have the potential to transform various industries and applications by providing fast, accurate, and efficient language processing capabilities.\"\n },\n \"logprobs\": null,\n \"finish_reason\": \"stop\"\n }\n ],\n \"usage\": {\n \"queue_time\": 0.037493756,\n \"prompt_tokens\": 18,\n \"prompt_time\": 0.000680594,\n \"completion_tokens\": 556,\n \"completion_time\": 0.463333333,\n \"total_tokens\": 574,\n \"total_time\": 0.464013927\n },\n \"system_fingerprint\": \"fp_179b0f92c9\",\n \"x_groq\": { \"id\": \"req_01jbd6g2qdfw2adyrt2az8hz4w\" }\n}\n"])</script><script>self.__next_f.push([1,"22:T699,{\n \"object\": \"list\",\n \"data\": [\n {\n \"id\": \"gemma2-9b-it\",\n \"object\": \"model\",\n \"created\": 1693721698,\n \"owned_by\": \"Google\",\n \"active\": true,\n \"context_window\": 8192,\n \"public_apps\": null\n },\n {\n \"id\": \"llama3-8b-8192\",\n \"object\": \"model\",\n \"created\": 1693721698,\n \"owned_by\": \"Meta\",\n \"active\": true,\n \"context_window\": 8192,\n \"public_apps\": null\n },\n {\n \"id\": \"llama3-70b-8192\",\n \"object\": \"model\",\n \"created\": 1693721698,\n \"owned_by\": \"Meta\",\n \"active\": true,\n \"context_window\": 8192,\n \"public_apps\": null\n },\n {\n \"id\": \"whisper-large-v3-turbo\",\n \"object\": \"model\",\n \"created\": 1728413088,\n \"owned_by\": \"OpenAI\",\n \"active\": true,\n \"context_window\": 448,\n \"public_apps\": null\n },\n {\n \"id\": \"whisper-large-v3\",\n \"object\": \"model\",\n \"created\": 1693721698,\n \"owned_by\": \"OpenAI\",\n \"active\": true,\n \"context_window\": 448,\n \"public_apps\": null\n },\n {\n \"id\": \"llama-guard-3-8b\",\n \"object\": \"model\",\n \"created\": 1693721698,\n \"owned_by\": \"Meta\",\n \"active\": true,\n \"context_window\": 8192,\n \"public_apps\": null\n },\n {\n \"id\": \"distil-whisper-large-v3-en\",\n \"object\": \"model\",\n \"created\": 1693721698,\n \"owned_by\": \"Hugging Face\",\n \"active\": true,\n \"context_window\": 448,\n \"public_apps\": null\n },\n {\n \"id\": \"llama-3.1-8b-instant\",\n \"object\": \"model\",\n \"created\": 1693721698,\n \"owned_by\": \"Meta\",\n \"active\": true,\n \"context_window\": 131072,\n \"public_apps\": null\n }\n ]\n}\n"])</script><script>self.__next_f.push([1,"8:[\"$\",\"$L20\",null,{\"openapiSpec\":{\"components\":{\"schemas\":{\"Batch\":{\"properties\":{\"cancelled_at\":{\"description\":\"The Unix timestamp (in seconds) for when the batch was cancelled.\",\"type\":\"integer\"},\"cancelling_at\":{\"description\":\"The Unix timestamp (in seconds) for when the batch started cancelling.\",\"type\":\"integer\"},\"completed_at\":{\"description\":\"The Unix timestamp (in seconds) for when the batch was completed.\",\"type\":\"integer\"},\"completion_window\":{\"description\":\"The time frame within which the batch should be processed.\",\"type\":\"string\"},\"created_at\":{\"description\":\"The Unix timestamp (in seconds) for when the batch was created.\",\"type\":\"integer\"},\"endpoint\":{\"description\":\"The API endpoint used by the batch.\",\"type\":\"string\"},\"error_file_id\":{\"description\":\"The ID of the file containing the outputs of requests with errors.\",\"type\":\"string\"},\"errors\":{\"properties\":{\"data\":{\"items\":{\"properties\":{\"code\":{\"description\":\"An error code identifying the error type.\",\"type\":\"string\"},\"line\":{\"description\":\"The line number of the input file where the error occurred, if applicable.\",\"nullable\":true,\"type\":\"integer\"},\"message\":{\"description\":\"A human-readable message providing more details about the error.\",\"type\":\"string\"},\"param\":{\"description\":\"The name of the parameter that caused the error, if applicable.\",\"nullable\":true,\"type\":\"string\"}},\"type\":\"object\"},\"type\":\"array\"},\"object\":{\"description\":\"The object type, which is always `list`.\",\"type\":\"string\"}},\"type\":\"object\"},\"expired_at\":{\"description\":\"The Unix timestamp (in seconds) for when the batch expired.\",\"type\":\"integer\"},\"expires_at\":{\"description\":\"The Unix timestamp (in seconds) for when the batch will expire.\",\"type\":\"integer\"},\"failed_at\":{\"description\":\"The Unix timestamp (in seconds) for when the batch failed.\",\"type\":\"integer\"},\"finalizing_at\":{\"description\":\"The Unix timestamp (in seconds) for when the batch started finalizing.\",\"type\":\"integer\"},\"id\":{\"type\":\"string\"},\"in_progress_at\":{\"description\":\"The Unix timestamp (in seconds) for when the batch started processing.\",\"type\":\"integer\"},\"input_file_id\":{\"description\":\"The ID of the input file for the batch.\",\"type\":\"string\"},\"metadata\":{\"description\":\"Set of key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format.\\n\",\"nullable\":true,\"type\":\"object\"},\"object\":{\"description\":\"The object type, which is always `batch`.\",\"enum\":[\"batch\"],\"type\":\"string\",\"x-stainless-const\":true},\"output_file_id\":{\"description\":\"The ID of the file containing the outputs of successfully executed requests.\",\"type\":\"string\"},\"request_counts\":{\"description\":\"The request counts for different statuses within the batch.\",\"properties\":{\"completed\":{\"description\":\"Number of requests that have been completed successfully.\",\"type\":\"integer\"},\"failed\":{\"description\":\"Number of requests that have failed.\",\"type\":\"integer\"},\"total\":{\"description\":\"Total number of requests in the batch.\",\"type\":\"integer\"}},\"required\":[\"total\",\"completed\",\"failed\"],\"type\":\"object\"},\"status\":{\"description\":\"The current status of the batch.\",\"enum\":[\"validating\",\"failed\",\"in_progress\",\"finalizing\",\"completed\",\"expired\",\"cancelling\",\"cancelled\"],\"type\":\"string\"}},\"required\":[\"id\",\"object\",\"endpoint\",\"input_file_id\",\"completion_window\",\"status\",\"created_at\"],\"type\":\"object\"},\"BatchRequestInput\":{\"description\":\"The per-line object of the batch input file\",\"properties\":{\"custom_id\":{\"description\":\"A developer-provided per-request id that will be used to match outputs to inputs. Must be unique for each request in a batch.\",\"type\":\"string\"},\"method\":{\"description\":\"The HTTP method to be used for the request. Currently only `POST` is supported.\",\"enum\":[\"POST\"],\"type\":\"string\",\"x-stainless-const\":true},\"url\":{\"description\":\"The OpenAI API relative URL to be used for the request. Currently `/v1/chat/completions` is supported.\",\"type\":\"string\"}},\"type\":\"object\"},\"BatchRequestOutput\":{\"description\":\"The per-line object of the batch output and error files\",\"properties\":{\"custom_id\":{\"description\":\"A developer-provided per-request id that will be used to match outputs to inputs.\",\"type\":\"string\"},\"error\":{\"description\":\"For requests that failed with a non-HTTP error, this will contain more information on the cause of the failure.\",\"nullable\":true,\"properties\":{\"code\":{\"description\":\"A machine-readable error code.\",\"type\":\"string\"},\"message\":{\"description\":\"A human-readable error message.\",\"type\":\"string\"}},\"type\":\"object\"},\"id\":{\"type\":\"string\"},\"response\":{\"nullable\":true,\"properties\":{\"body\":{\"description\":\"The JSON body of the response\",\"type\":\"object\"},\"request_id\":{\"description\":\"An unique identifier for the OpenAI API request. Please include this request ID when contacting support.\",\"type\":\"string\"},\"status_code\":{\"description\":\"The HTTP status code of the response\",\"type\":\"integer\"}},\"type\":\"object\"}},\"type\":\"object\"},\"Chart\":{\"properties\":{\"elements\":{\"description\":\"The chart elements (data series, points, etc.)\",\"items\":{\"$ref\":\"#/components/schemas/ChartElement\"},\"type\":\"array\"},\"title\":{\"description\":\"The title of the chart\",\"type\":\"string\"},\"type\":{\"description\":\"The type of chart\",\"enum\":[\"bar\",\"box_and_whisker\",\"line\",\"pie\",\"scatter\",\"superchart\",\"unknown\"],\"type\":\"string\"},\"x_label\":{\"description\":\"The label for the x-axis\",\"type\":\"string\"},\"x_scale\":{\"description\":\"The scale type for the x-axis\",\"type\":\"string\"},\"x_tick_labels\":{\"description\":\"The labels for the x-axis ticks\",\"items\":{\"type\":\"string\"},\"type\":\"array\"},\"x_ticks\":{\"description\":\"The tick values for the x-axis\",\"items\":{\"type\":\"number\"},\"type\":\"array\"},\"x_unit\":{\"description\":\"The unit for the x-axis\",\"type\":\"string\"},\"y_label\":{\"description\":\"The label for the y-axis\",\"type\":\"string\"},\"y_scale\":{\"description\":\"The scale type for the y-axis\",\"type\":\"string\"},\"y_tick_labels\":{\"description\":\"The labels for the y-axis ticks\",\"items\":{\"type\":\"string\"},\"type\":\"array\"},\"y_ticks\":{\"description\":\"The tick values for the y-axis\",\"items\":{\"type\":\"number\"},\"type\":\"array\"},\"y_unit\":{\"description\":\"The unit for the y-axis\",\"type\":\"string\"}},\"required\":[\"type\",\"elements\"],\"type\":\"object\"},\"ChartElement\":{\"properties\":{\"angle\":{\"description\":\"The angle for this element\",\"type\":\"number\"},\"first_quartile\":{\"description\":\"The first quartile value for this element\",\"type\":\"number\"},\"group\":{\"description\":\"The group this element belongs to\",\"type\":\"string\"},\"label\":{\"description\":\"The label for this chart element\",\"type\":\"string\"},\"max\":{\"type\":\"number\"},\"median\":{\"description\":\"The median value for this element\",\"type\":\"number\"},\"min\":{\"description\":\"The minimum value for this element\",\"type\":\"number\"},\"outliers\":{\"description\":\"The outliers for this element\",\"items\":{\"type\":\"number\"},\"type\":\"array\"},\"points\":{\"description\":\"The points for this element\",\"items\":{\"items\":{\"type\":\"number\"},\"type\":\"array\"},\"type\":\"array\"},\"radius\":{\"description\":\"The radius for this element\",\"type\":\"number\"},\"third_quartile\":{\"description\":\"The third quartile value for this element\",\"type\":\"number\"},\"value\":{\"description\":\"The value for this element\",\"type\":\"number\"}},\"required\":[\"label\"],\"type\":\"object\"},\"ChatCompletionFunctionCallOption\":{\"description\":\"Specifying a particular function via `{\\\"name\\\": \\\"my_function\\\"}` forces the model to call that function.\\n\",\"properties\":{\"name\":{\"description\":\"The name of the function to call.\",\"type\":\"string\"}},\"required\":[\"name\"],\"type\":\"object\"},\"ChatCompletionFunctions\":{\"deprecated\":true,\"properties\":{\"description\":{\"description\":\"A description of what the function does, used by the model to choose when and how to call the function.\",\"type\":\"string\"},\"name\":{\"description\":\"The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 64.\",\"type\":\"string\"},\"parameters\":{\"$ref\":\"#/components/schemas/FunctionParameters\"}},\"required\":[\"name\"],\"type\":\"object\"},\"ChatCompletionMessageExecutedTools\":{\"description\":\"A list of tools that were executed during the chat completion for compound AI systems.\",\"items\":{\"properties\":{\"arguments\":{\"description\":\"The arguments passed to the tool in JSON format.\",\"type\":\"string\"},\"code_results\":{\"description\":\"Array of code execution results\",\"items\":{\"$ref\":\"#/components/schemas/CodeExecutionResult\"},\"type\":\"array\"},\"index\":{\"description\":\"The index of the executed tool.\",\"type\":\"integer\"},\"output\":{\"description\":\"The output returned by the tool.\",\"nullable\":true,\"type\":\"string\"},\"search_results\":{\"description\":\"The search results returned by the tool, if applicable.\",\"nullable\":true,\"properties\":{\"images\":{\"description\":\"List of image URLs returned by the search\",\"items\":{\"type\":\"string\"},\"type\":\"array\"},\"results\":{\"description\":\"List of search results\",\"items\":{\"properties\":{\"content\":{\"description\":\"The content of the search result\",\"type\":\"string\"},\"score\":{\"description\":\"The relevance score of the search result\",\"format\":\"float\",\"type\":\"number\"},\"title\":{\"description\":\"The title of the search result\",\"type\":\"string\"},\"url\":{\"description\":\"The URL of the search result\",\"type\":\"string\"}},\"type\":\"object\"},\"type\":\"array\"}},\"type\":\"object\"},\"type\":{\"description\":\"The type of tool that was executed.\",\"type\":\"string\"}},\"required\":[\"index\",\"type\",\"arguments\"],\"type\":\"object\"},\"type\":\"array\"},\"ChatCompletionMessageToolCall\":{\"properties\":{\"function\":{\"description\":\"The function that the model called.\",\"properties\":{\"arguments\":{\"description\":\"The arguments to call the function with, as generated by the model in JSON format. Note that the model does not always generate valid JSON, and may hallucinate parameters not defined by your function schema. Validate the arguments in your code before calling your function.\",\"type\":\"string\"},\"name\":{\"description\":\"The name of the function to call.\",\"type\":\"string\"}},\"required\":[\"name\",\"arguments\"],\"type\":\"object\"},\"id\":{\"description\":\"The ID of the tool call.\",\"type\":\"string\"},\"type\":{\"description\":\"The type of the tool. Currently, only `function` is supported.\",\"enum\":[\"function\"],\"type\":\"string\"}},\"required\":[\"id\",\"type\",\"function\"],\"type\":\"object\"},\"ChatCompletionMessageToolCallChunk\":{\"properties\":{\"function\":{\"properties\":{\"arguments\":{\"description\":\"The arguments to call the function with, as generated by the model in JSON format. Note that the model does not always generate valid JSON, and may hallucinate parameters not defined by your function schema. Validate the arguments in your code before calling your function.\",\"type\":\"string\"},\"name\":{\"description\":\"The name of the function to call.\",\"type\":\"string\"}},\"type\":\"object\"},\"id\":{\"description\":\"The ID of the tool call.\",\"type\":\"string\"},\"index\":{\"type\":\"integer\"},\"type\":{\"description\":\"The type of the tool. Currently, only `function` is supported.\",\"enum\":[\"function\"],\"type\":\"string\"}},\"required\":[\"index\"],\"type\":\"object\"},\"ChatCompletionMessageToolCalls\":{\"description\":\"The tool calls generated by the model, such as function calls.\",\"items\":{\"$ref\":\"#/components/schemas/ChatCompletionMessageToolCall\"},\"type\":\"array\"},\"ChatCompletionNamedToolChoice\":{\"description\":\"Specifies a tool the model should use. Use to force the model to call a specific function.\",\"properties\":{\"function\":{\"properties\":{\"name\":{\"description\":\"The name of the function to call.\",\"type\":\"string\"}},\"required\":[\"name\"],\"type\":\"object\"},\"type\":{\"description\":\"The type of the tool. Currently, only `function` is supported.\",\"enum\":[\"function\"],\"type\":\"string\"}},\"required\":[\"type\",\"function\"],\"type\":\"object\"},\"ChatCompletionRequestAssistantMessage\":{\"additionalProperties\":false,\"properties\":{\"content\":{\"description\":\"The contents of the assistant message. Required unless `tool_calls` or `function_call` is specified.\\n\",\"nullable\":true,\"type\":\"string\"},\"function_call\":{\"deprecated\":true,\"description\":\"Deprecated and replaced by `tool_calls`. The name and arguments of a function that should be called, as generated by the model.\",\"properties\":{\"arguments\":{\"description\":\"The arguments to call the function with, as generated by the model in JSON format. Note that the model does not always generate valid JSON, and may hallucinate parameters not defined by your function schema. Validate the arguments in your code before calling your function.\",\"type\":\"string\"},\"name\":{\"description\":\"The name of the function to call.\",\"type\":\"string\"}},\"type\":\"object\"},\"name\":{\"description\":\"An optional name for the participant. Provides the model information to differentiate between participants of the same role.\",\"type\":\"string\"},\"reasoning\":{\"description\":\"The reasoning output by the assistant if reasoning_format was set to 'parsed'.\\nThis field is only useable with qwen3 models.\\n\",\"nullable\":true,\"type\":\"string\"},\"role\":{\"description\":\"The role of the messages author, in this case `assistant`.\",\"enum\":[\"assistant\"],\"type\":\"string\"},\"tool_call_id\":{\"description\":\"DO NOT USE. This field is present because OpenAI allows it and users send it.\",\"nullable\":true,\"required\":[\"arguments\",\"name\"],\"type\":\"string\",\"x-groq-meta\":{\"hidden\":true}},\"tool_calls\":{\"$ref\":\"#/components/schemas/ChatCompletionMessageToolCalls\"}},\"required\":[\"role\"],\"title\":\"Assistant message\",\"type\":\"object\"},\"ChatCompletionRequestFunctionMessage\":{\"additionalProperties\":false,\"deprecated\":true,\"properties\":{\"content\":{\"description\":\"The contents of the function message.\",\"nullable\":true,\"type\":\"string\"},\"name\":{\"description\":\"The name of the function to call.\",\"type\":\"string\"},\"role\":{\"description\":\"The role of the messages author, in this case `function`.\",\"enum\":[\"function\"],\"type\":\"string\"},\"tool_call_id\":{\"description\":\"DO NOT USE. This field is present because OpenAI allows it and users send it.\",\"nullable\":true,\"type\":\"string\",\"x-groq-meta\":{\"hidden\":true}}},\"required\":[\"role\",\"content\",\"name\"],\"title\":\"Function message\",\"type\":\"object\"},\"ChatCompletionRequestMessage\":{\"discriminator\":{\"mapping\":{\"assistant\":\"#/components/schemas/ChatCompletionRequestAssistantMessage\",\"function\":\"#/components/schemas/ChatCompletionRequestFunctionMessage\",\"system\":\"#/components/schemas/ChatCompletionRequestSystemMessage\",\"tool\":\"#/components/schemas/ChatCompletionRequestToolMessage\",\"user\":\"#/components/schemas/ChatCompletionRequestUserMessage\"},\"propertyName\":\"role\"},\"oneOf\":[{\"$ref\":\"#/components/schemas/ChatCompletionRequestSystemMessage\"},{\"$ref\":\"#/components/schemas/ChatCompletionRequestUserMessage\"},{\"$ref\":\"#/components/schemas/ChatCompletionRequestAssistantMessage\"},{\"$ref\":\"#/components/schemas/ChatCompletionRequestToolMessage\"},{\"$ref\":\"#/components/schemas/ChatCompletionRequestFunctionMessage\"}]},\"ChatCompletionRequestMessageContentPart\":{\"oneOf\":[{\"$ref\":\"#/components/schemas/ChatCompletionRequestMessageContentPartText\"},{\"$ref\":\"#/components/schemas/ChatCompletionRequestMessageContentPartImage\"}]},\"ChatCompletionRequestMessageContentPartImage\":{\"properties\":{\"image_url\":{\"properties\":{\"detail\":{\"default\":\"auto\",\"description\":\"Specifies the detail level of the image.\",\"enum\":[\"auto\",\"low\",\"high\"],\"type\":\"string\"},\"url\":{\"description\":\"Either a URL of the image or the base64 encoded image data.\",\"format\":\"uri\",\"type\":\"string\"}},\"required\":[\"url\"],\"type\":\"object\"},\"type\":{\"description\":\"The type of the content part.\",\"enum\":[\"image_url\"],\"type\":\"string\"}},\"required\":[\"type\",\"image_url\"],\"title\":\"Image content part\",\"type\":\"object\"},\"ChatCompletionRequestMessageContentPartText\":{\"properties\":{\"text\":{\"description\":\"The text content.\",\"type\":\"string\"},\"type\":{\"description\":\"The type of the content part.\",\"enum\":[\"text\"],\"type\":\"string\"}},\"required\":[\"type\",\"text\"],\"title\":\"Text content part\",\"type\":\"object\"},\"ChatCompletionRequestSystemMessage\":{\"additionalProperties\":false,\"properties\":{\"content\":{\"description\":\"The contents of the system message.\",\"type\":\"string\"},\"name\":{\"description\":\"An optional name for the participant. Provides the model information to differentiate between participants of the same role.\",\"type\":\"string\"},\"role\":{\"description\":\"The role of the messages author, in this case `system`.\",\"enum\":[\"system\"],\"type\":\"string\"},\"tool_call_id\":{\"description\":\"DO NOT USE. This field is present because OpenAI allows it and users send it.\",\"nullable\":true,\"type\":\"string\",\"x-groq-meta\":{\"hidden\":true}}},\"required\":[\"content\",\"role\"],\"title\":\"System message\",\"type\":\"object\"},\"ChatCompletionRequestToolMessage\":{\"additionalProperties\":false,\"properties\":{\"content\":{\"description\":\"The contents of the tool message.\",\"type\":\"string\"},\"name\":{\"description\":\"DO NOT USE. This field is present because OpenAI allows it and users send it.\",\"type\":\"string\",\"x-groq-meta\":{\"hidden\":true}},\"role\":{\"description\":\"The role of the messages author, in this case `tool`.\",\"enum\":[\"tool\"],\"type\":\"string\"},\"tool_call_id\":{\"description\":\"Tool call that this message is responding to.\",\"type\":\"string\"}},\"required\":[\"role\",\"content\",\"tool_call_id\"],\"title\":\"Tool message\",\"type\":\"object\"},\"ChatCompletionRequestUserMessage\":{\"additionalProperties\":false,\"properties\":{\"content\":{\"description\":\"The contents of the user message.\\n\",\"oneOf\":[{\"description\":\"The text contents of the message.\",\"title\":\"Text content\",\"type\":\"string\"},{\"description\":\"An array of content parts with a defined type, each can be of type `text` or `image_url` when passing in images. You can pass multiple images by adding multiple `image_url` content parts. Image input is only supported when using the `gpt-4-visual-preview` model.\",\"items\":{\"$ref\":\"#/components/schemas/ChatCompletionRequestMessageContentPart\"},\"minItems\":1,\"title\":\"Array of content parts\",\"type\":\"array\"}]},\"name\":{\"description\":\"An optional name for the participant. Provides the model information to differentiate between participants of the same role.\",\"type\":\"string\"},\"role\":{\"description\":\"The role of the messages author, in this case `user`.\",\"enum\":[\"user\"],\"type\":\"string\"},\"tool_call_id\":{\"description\":\"DO NOT USE. This field is present because OpenAI allows it and users send it.\",\"nullable\":true,\"type\":\"string\",\"x-groq-meta\":{\"hidden\":true}}},\"required\":[\"content\",\"role\"],\"title\":\"User message\",\"type\":\"object\"},\"ChatCompletionResponseMessage\":{\"description\":\"A chat completion message generated by the model.\",\"properties\":{\"content\":{\"description\":\"The contents of the message.\",\"nullable\":true,\"type\":\"string\"},\"executed_tools\":{\"$ref\":\"#/components/schemas/ChatCompletionMessageExecutedTools\"},\"function_call\":{\"deprecated\":true,\"description\":\"Deprecated and replaced by `tool_calls`. The name and arguments of a function that should be called, as generated by the model.\",\"properties\":{\"arguments\":{\"description\":\"The arguments to call the function with, as generated by the model in JSON format. Note that the model does not always generate valid JSON, and may hallucinate parameters not defined by your function schema. Validate the arguments in your code before calling your function.\",\"type\":\"string\"},\"name\":{\"description\":\"The name of the function to call.\",\"type\":\"string\"}},\"required\":[\"name\",\"arguments\"],\"type\":\"object\"},\"reasoning\":{\"description\":\"The model's reasoning for a response. Only available for reasoning models when requests parameter reasoning_format has value `parsed.\",\"nullable\":true,\"type\":\"string\"},\"role\":{\"description\":\"The role of the author of this message.\",\"enum\":[\"assistant\"],\"type\":\"string\"},\"tool_calls\":{\"$ref\":\"#/components/schemas/ChatCompletionMessageToolCalls\"}},\"required\":[\"role\",\"content\"],\"type\":\"object\"},\"ChatCompletionRole\":{\"description\":\"The role of the author of a message\",\"enum\":[\"system\",\"user\",\"assistant\",\"tool\",\"function\"],\"type\":\"string\"},\"ChatCompletionStreamOptions\":{\"description\":\"Options for streaming response. Only set this when you set `stream: true`.\\n\",\"nullable\":true,\"properties\":{\"include_usage\":{\"description\":\"If set, an additional chunk will be streamed before the `data: [DONE]` message. The `usage` field on this chunk shows the token usage statistics for the entire request, and the `choices` field will always be an empty array. All other chunks will also include a `usage` field, but with a null value.\\n\",\"nullable\":true,\"type\":\"boolean\"}},\"type\":\"object\"},\"ChatCompletionStreamResponseDelta\":{\"description\":\"A chat completion delta generated by streamed model responses.\",\"properties\":{\"content\":{\"description\":\"The contents of the chunk message.\",\"nullable\":true,\"type\":\"string\"},\"executed_tools\":{\"$ref\":\"#/components/schemas/ChatCompletionMessageExecutedTools\"},\"function_call\":{\"deprecated\":true,\"description\":\"Deprecated and replaced by `tool_calls`. The name and arguments of a function that should be called, as generated by the model.\",\"properties\":{\"arguments\":{\"description\":\"The arguments to call the function with, as generated by the model in JSON format. Note that the model does not always generate valid JSON, and may hallucinate parameters not defined by your function schema. Validate the arguments in your code before calling your function.\",\"type\":\"string\"},\"name\":{\"description\":\"The name of the function to call.\",\"type\":\"string\"}},\"type\":\"object\"},\"reasoning\":{\"description\":\"The model's reasoning for a response. Only available for reasoning models when requests parameter reasoning_format has value `parsed.\",\"nullable\":true,\"type\":\"string\"},\"role\":{\"description\":\"The role of the author of this message.\",\"enum\":[\"system\",\"user\",\"assistant\",\"tool\"],\"type\":\"string\"},\"tool_calls\":{\"items\":{\"$ref\":\"#/components/schemas/ChatCompletionMessageToolCallChunk\"},\"type\":\"array\"}},\"type\":\"object\"},\"ChatCompletionTokenLogprob\":{\"properties\":{\"bytes\":{\"description\":\"A list of integers representing the UTF-8 bytes representation of the token. Useful in instances where characters are represented by multiple tokens and their byte representations must be combined to generate the correct text representation. Can be `null` if there is no bytes representation for the token.\",\"items\":{\"type\":\"integer\"},\"nullable\":true,\"type\":\"array\"},\"logprob\":{\"description\":\"The log probability of this token, if it is within the top 20 most likely tokens. Otherwise, the value `-9999.0` is used to signify that the token is very unlikely.\",\"type\":\"number\"},\"token\":{\"description\":\"The token.\",\"type\":\"string\"},\"top_logprobs\":{\"description\":\"List of the most likely tokens and their log probability, at this token position. In rare cases, there may be fewer than the number of requested `top_logprobs` returned.\",\"items\":{\"properties\":{\"bytes\":{\"description\":\"A list of integers representing the UTF-8 bytes representation of the token. Useful in instances where characters are represented by multiple tokens and their byte representations must be combined to generate the correct text representation. Can be `null` if there is no bytes representation for the token.\",\"items\":{\"type\":\"integer\"},\"nullable\":true,\"type\":\"array\"},\"logprob\":{\"description\":\"The log probability of this token, if it is within the top 20 most likely tokens. Otherwise, the value `-9999.0` is used to signify that the token is very unlikely.\",\"type\":\"number\"},\"token\":{\"description\":\"The token.\",\"type\":\"string\"}},\"required\":[\"token\",\"logprob\",\"bytes\"],\"type\":\"object\"},\"type\":\"array\"}},\"required\":[\"token\",\"logprob\",\"bytes\",\"top_logprobs\"],\"type\":\"object\"},\"ChatCompletionTool\":{\"properties\":{\"function\":{\"$ref\":\"#/components/schemas/FunctionObject\"},\"type\":{\"description\":\"The type of the tool. Currently, only `function` is supported.\",\"enum\":[\"function\"],\"type\":\"string\"}},\"required\":[\"type\",\"function\"],\"type\":\"object\"},\"ChatCompletionToolChoiceOption\":{\"description\":\"Controls which (if any) tool is called by the model.\\n`none` means the model will not call any tool and instead generates a message.\\n`auto` means the model can pick between generating a message or calling one or more tools.\\n`required` means the model must call one or more tools.\\nSpecifying a particular tool via `{\\\"type\\\": \\\"function\\\", \\\"function\\\": {\\\"name\\\": \\\"my_function\\\"}}` forces the model to call that tool.\\n\\n`none` is the default when no tools are present. `auto` is the default if tools are present.\\n\",\"nullable\":true,\"oneOf\":[{\"description\":\"`none` means the model will not call any tool and instead generates a message. `auto` means the model can pick between generating a message or calling one or more tools.\\n\",\"enum\":[\"none\",\"auto\",\"required\"],\"type\":\"string\"},{\"$ref\":\"#/components/schemas/ChatCompletionNamedToolChoice\"}],\"x-groq-meta\":{\"validator\":\"ChatCompletionToolChoiceOption\"}},\"ChatCompletionUsageBreakdown\":{\"description\":\"Usage statistics for compound AI completion requests.\",\"properties\":{\"models\":{\"description\":\"List of models used in the request and their individual usage statistics\",\"items\":{\"properties\":{\"model\":{\"description\":\"The name/identifier of the model used\",\"type\":\"string\"},\"usage\":{\"$ref\":\"#/components/schemas/CompletionUsage\"}},\"required\":[\"model\",\"usage\"],\"type\":\"object\"},\"type\":\"array\"}},\"required\":[\"models\"],\"type\":\"object\"},\"CodeExecutionOutput\":{\"additionalProperties\":false,\"properties\":{\"results\":{\"description\":\"Array of code execution results\",\"items\":{\"$ref\":\"#/components/schemas/CodeExecutionResult\"},\"type\":\"array\"},\"stdout\":{\"description\":\"Standard output from code execution\",\"type\":\"string\"}},\"required\":[\"stdout\"],\"type\":\"object\"},\"CodeExecutionResult\":{\"additionalProperties\":false,\"properties\":{\"chart\":{\"$ref\":\"#/components/schemas/Chart\"},\"charts\":{\"description\":\"Array of charts from a superchart\",\"items\":{\"$ref\":\"#/components/schemas/Chart\"},\"type\":\"array\"},\"png\":{\"description\":\"Base64 encoded PNG image output from code execution\",\"type\":\"string\"},\"text\":{\"description\":\"The text version of the code execution result\",\"type\":\"string\"}},\"type\":\"object\"},\"CompletionUsage\":{\"description\":\"Usage statistics for the completion request.\",\"properties\":{\"completion_time\":{\"description\":\"Time spent generating tokens\",\"type\":\"number\"},\"completion_tokens\":{\"description\":\"Number of tokens in the generated completion.\",\"type\":\"integer\"},\"prompt_time\":{\"description\":\"Time spent processing input tokens\",\"type\":\"number\"},\"prompt_tokens\":{\"description\":\"Number of tokens in the prompt.\",\"type\":\"integer\"},\"queue_time\":{\"description\":\"Time the requests was spent queued\",\"type\":\"number\"},\"total_time\":{\"description\":\"completion time and prompt time combined\",\"type\":\"number\"},\"total_tokens\":{\"description\":\"Total number of tokens used in the request (prompt + completion).\",\"type\":\"integer\"}},\"required\":[\"prompt_tokens\",\"completion_tokens\",\"total_tokens\"],\"type\":\"object\"},\"CreateChatCompletionRequest\":{\"additionalProperties\":false,\"properties\":{\"exclude_domains\":{\"deprecated\":true,\"description\":\"Deprecated: Use search_settings.exclude_domains instead.\\nA list of domains to exclude from the search results when the model uses a web search tool.\\n\",\"items\":{\"type\":\"string\"},\"nullable\":true,\"type\":\"array\"},\"frequency_penalty\":{\"default\":0,\"description\":\"Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim.\",\"maximum\":2,\"minimum\":-2,\"nullable\":true,\"type\":\"number\"},\"function_call\":{\"deprecated\":true,\"description\":\"Deprecated in favor of `tool_choice`.\\n\\nControls which (if any) function is called by the model.\\n`none` means the model will not call a function and instead generates a message.\\n`auto` means the model can pick between generating a message or calling a function.\\nSpecifying a particular function via `{\\\"name\\\": \\\"my_function\\\"}` forces the model to call that function.\\n\\n`none` is the default when no functions are present. `auto` is the default if functions are present.\\n\",\"nullable\":true,\"oneOf\":[{\"description\":\"`none` means the model will not call a function and instead generates a message. `auto` means the model can pick between generating a message or calling a function.\\n\",\"enum\":[\"none\",\"auto\",\"required\"],\"type\":\"string\"},{\"$ref\":\"#/components/schemas/ChatCompletionFunctionCallOption\"}]},\"functions\":{\"deprecated\":true,\"description\":\"Deprecated in favor of `tools`.\\n\\nA list of functions the model may generate JSON inputs for.\\n\",\"items\":{\"$ref\":\"#/components/schemas/ChatCompletionFunctions\"},\"maxItems\":128,\"nullable\":true,\"type\":\"array\"},\"include_domains\":{\"deprecated\":true,\"description\":\"Deprecated: Use search_settings.include_domains instead.\\nA list of domains to include in the search results when the model uses a web search tool.\\n\",\"items\":{\"type\":\"string\"},\"nullable\":true,\"type\":\"array\"},\"logit_bias\":{\"additionalProperties\":{\"type\":\"integer\"},\"description\":\"This is not yet supported by any of our models.\\nModify the likelihood of specified tokens appearing in the completion.\\n\",\"nullable\":true,\"type\":\"object\"},\"logprobs\":{\"default\":false,\"description\":\"This is not yet supported by any of our models.\\nWhether to return log probabilities of the output tokens or not. If true, returns the log probabilities of each output token returned in the `content` of `message`.\\n\",\"nullable\":true,\"type\":\"boolean\"},\"max_completion_tokens\":{\"description\":\"The maximum number of tokens that can be generated in the chat completion. The total length of input tokens and generated tokens is limited by the model's context length.\",\"nullable\":true,\"type\":\"integer\"},\"max_tokens\":{\"deprecated\":true,\"description\":\"Deprecated in favor of `max_completion_tokens`.\\nThe maximum number of tokens that can be generated in the chat completion. The total length of input tokens and generated tokens is limited by the model's context length.\\n\",\"nullable\":true,\"type\":\"integer\"},\"messages\":{\"description\":\"A list of messages comprising the conversation so far.\",\"items\":{\"$ref\":\"#/components/schemas/ChatCompletionRequestMessage\"},\"minItems\":1,\"type\":\"array\"},\"metadata\":{\"additionalProperties\":{\"type\":\"string\"},\"description\":\"This parameter is not currently supported.\\n\",\"nullable\":true,\"type\":\"object\"},\"model\":{\"anyOf\":[{\"type\":\"string\"},{\"enum\":[\"gemma2-9b-it\",\"llama-3.3-70b-versatile\",\"llama-3.1-8b-instant\",\"llama-guard-3-8b\",\"llama3-70b-8192\",\"llama3-8b-8192\"],\"type\":\"string\"}],\"description\":\"ID of the model to use. For details on which models are compatible with the Chat API, see available [models](https://console.groq.com/docs/models)\",\"example\":\"meta-llama/llama-4-scout-17b-16e-instruct\"},\"n\":{\"default\":1,\"description\":\"How many chat completion choices to generate for each input message. Note that the current moment, only n=1 is supported. Other values will result in a 400 response.\",\"example\":1,\"maximum\":1,\"minimum\":1,\"nullable\":true,\"type\":\"integer\"},\"parallel_tool_calls\":{\"default\":true,\"description\":\"Whether to enable parallel function calling during tool use.\\n\",\"nullable\":true,\"type\":\"boolean\"},\"presence_penalty\":{\"default\":0,\"description\":\"Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics.\",\"maximum\":2,\"minimum\":-2,\"nullable\":true,\"type\":\"number\"},\"reasoning_effort\":{\"description\":\"this field is only available for qwen3 models.\\nSet to 'none' to disable reasoning.\\nSet to 'default' or null to let Qwen reason.\\n\",\"enum\":[\"none\",\"default\"],\"nullable\":true,\"type\":\"string\"},\"reasoning_format\":{\"description\":\"Specifies how to output reasoning tokens\\n\",\"enum\":[\"hidden\",\"raw\",\"parsed\"],\"nullable\":true,\"type\":\"string\"},\"response_format\":{\"description\":\"An object specifying the format that the model must output. Setting to `{ \\\"type\\\": \\\"json_schema\\\", \\\"json_schema\\\": {...} }` enables Structured Outputs which ensures the model will match your supplied JSON schema. json_schema response format is only supported on llama 4 models. Setting to `{ \\\"type\\\": \\\"json_object\\\" }` enables the older JSON mode, which ensures the message the model generates is valid JSON. Using `json_schema` is preferred for models that support it.\\n\",\"nullable\":true,\"oneOf\":[{\"$ref\":\"#/components/schemas/ResponseFormatText\"},{\"$ref\":\"#/components/schemas/ResponseFormatJsonSchema\"},{\"$ref\":\"#/components/schemas/ResponseFormatJsonObject\"}]},\"search_settings\":{\"description\":\"Settings for web search functionality when the model uses a web search tool.\\n\",\"nullable\":true,\"properties\":{\"exclude_domains\":{\"description\":\"A list of domains to exclude from the search results.\",\"items\":{\"type\":\"string\"},\"nullable\":true,\"type\":\"array\"},\"include_domains\":{\"description\":\"A list of domains to include in the search results.\",\"items\":{\"type\":\"string\"},\"nullable\":true,\"type\":\"array\"},\"include_images\":{\"description\":\"Whether to include images in the search results.\",\"nullable\":true,\"type\":\"boolean\"}},\"type\":\"object\"},\"seed\":{\"description\":\"If specified, our system will make a best effort to sample deterministically, such that repeated requests with the same `seed` and parameters should return the same result.\\nDeterminism is not guaranteed, and you should refer to the `system_fingerprint` response parameter to monitor changes in the backend.\\n\",\"nullable\":true,\"type\":\"integer\"},\"service_tier\":{\"description\":\"The service tier to use for the request. Defaults to `on_demand`.\\n- `auto` will automatically select the highest tier available within the rate limits of your organization.\\n- `flex` uses the flex tier, which will succeed or fail quickly.\\n\",\"enum\":[\"auto\",\"on_demand\",\"flex\",null],\"nullable\":true,\"type\":\"string\"},\"stop\":{\"description\":\"Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.\\n\",\"nullable\":true,\"oneOf\":[{\"example\":\"\\n\",\"nullable\":true,\"type\":\"string\"},{\"items\":{\"example\":\"[\\\"\\\\n\\\"]\",\"type\":\"string\"},\"maxItems\":4,\"type\":\"array\"}]},\"store\":{\"description\":\"This parameter is not currently supported.\\n\",\"nullable\":true,\"type\":\"boolean\"},\"stream\":{\"default\":false,\"description\":\"If set, partial message deltas will be sent. Tokens will be sent as data-only [server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format) as they become available, with the stream terminated by a `data: [DONE]` message. [Example code](/docs/text-chat#streaming-a-chat-completion).\\n\",\"nullable\":true,\"type\":\"boolean\"},\"stream_options\":{\"$ref\":\"#/components/schemas/ChatCompletionStreamOptions\"},\"temperature\":{\"default\":1,\"description\":\"What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. We generally recommend altering this or top_p but not both.\",\"example\":1,\"maximum\":2,\"minimum\":0,\"nullable\":true,\"type\":\"number\"},\"tool_choice\":{\"$ref\":\"#/components/schemas/ChatCompletionToolChoiceOption\"},\"tools\":{\"description\":\"A list of tools the model may call. Currently, only functions are supported as a tool. Use this to provide a list of functions the model may generate JSON inputs for. A max of 128 functions are supported.\\n\",\"items\":{\"$ref\":\"#/components/schemas/ChatCompletionTool\"},\"maxItems\":128,\"nullable\":true,\"type\":\"array\"},\"top_logprobs\":{\"description\":\"This is not yet supported by any of our models.\\nAn integer between 0 and 20 specifying the number of most likely tokens to return at each token position, each with an associated log probability. `logprobs` must be set to `true` if this parameter is used.\\n\",\"maximum\":20,\"minimum\":0,\"nullable\":true,\"type\":\"integer\"},\"top_p\":{\"default\":1,\"description\":\"An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. We generally recommend altering this or temperature but not both.\",\"example\":1,\"maximum\":1,\"minimum\":0,\"nullable\":true,\"type\":\"number\"},\"user\":{\"description\":\"A unique identifier representing your end-user, which can help us monitor and detect abuse.\",\"nullable\":true,\"type\":\"string\"}},\"required\":[\"model\",\"messages\"],\"type\":\"object\"},\"CreateChatCompletionResponse\":{\"description\":\"Represents a chat completion response returned by model, based on the provided input.\",\"properties\":{\"choices\":{\"description\":\"A list of chat completion choices. Can be more than one if `n` is greater than 1.\",\"items\":{\"properties\":{\"finish_reason\":{\"description\":\"The reason the model stopped generating tokens. This will be `stop` if the model hit a natural stop point or a provided stop sequence,\\n`length` if the maximum number of tokens specified in the request was reached,\\n`tool_calls` if the model called a tool, or `function_call` (deprecated) if the model called a function.\\n\",\"enum\":[\"stop\",\"length\",\"tool_calls\",\"function_call\"],\"type\":\"string\"},\"index\":{\"description\":\"The index of the choice in the list of choices.\",\"type\":\"integer\"},\"logprobs\":{\"description\":\"Log probability information for the choice.\",\"nullable\":true,\"properties\":{\"content\":{\"description\":\"A list of message content tokens with log probability information.\",\"items\":{\"$ref\":\"#/components/schemas/ChatCompletionTokenLogprob\"},\"nullable\":true,\"type\":\"array\"}},\"required\":[\"content\"],\"type\":\"object\"},\"message\":{\"$ref\":\"#/components/schemas/ChatCompletionResponseMessage\"}},\"required\":[\"finish_reason\",\"index\",\"message\",\"logprobs\"],\"type\":\"object\"},\"type\":\"array\"},\"created\":{\"description\":\"The Unix timestamp (in seconds) of when the chat completion was created.\",\"type\":\"integer\"},\"id\":{\"description\":\"A unique identifier for the chat completion.\",\"type\":\"string\"},\"model\":{\"description\":\"The model used for the chat completion.\",\"type\":\"string\"},\"object\":{\"description\":\"The object type, which is always `chat.completion`.\",\"enum\":[\"chat.completion\"],\"type\":\"string\"},\"system_fingerprint\":{\"description\":\"This fingerprint represents the backend configuration that the model runs with.\\n\\nCan be used in conjunction with the `seed` request parameter to understand when backend changes have been made that might impact determinism.\\n\",\"type\":\"string\"},\"usage\":{\"$ref\":\"#/components/schemas/CompletionUsage\"},\"usage_breakdown\":{\"$ref\":\"#/components/schemas/ChatCompletionUsageBreakdown\"}},\"required\":[\"choices\",\"created\",\"id\",\"model\",\"object\"],\"type\":\"object\"},\"CreateChatCompletionStreamResponse\":{\"description\":\"Represents a streamed chunk of a chat completion response returned by model, based on the provided input.\",\"properties\":{\"choices\":{\"description\":\"A list of chat completion choices. Can contain more than one elements if `n` is greater than 1.\\n\",\"items\":{\"properties\":{\"delta\":{\"$ref\":\"#/components/schemas/ChatCompletionStreamResponseDelta\"},\"finish_reason\":{\"description\":\"The reason the model stopped generating tokens. This will be `stop` if the model hit a natural stop point or a provided stop sequence,\\n`length` if the maximum number of tokens specified in the request was reached,\\n`tool_calls` if the model called a tool, or `function_call` (deprecated) if the model called a function.\\n\",\"enum\":[\"stop\",\"length\",\"tool_calls\",\"function_call\"],\"nullable\":true,\"type\":\"string\"},\"index\":{\"description\":\"The index of the choice in the list of choices.\",\"type\":\"integer\"},\"logprobs\":{\"description\":\"Log probability information for the choice.\",\"nullable\":true,\"properties\":{\"content\":{\"description\":\"A list of message content tokens with log probability information.\",\"items\":{\"$ref\":\"#/components/schemas/ChatCompletionTokenLogprob\"},\"nullable\":true,\"type\":\"array\"}},\"required\":[\"content\"],\"type\":\"object\"}},\"required\":[\"delta\",\"finish_reason\",\"index\"],\"type\":\"object\"},\"type\":\"array\"},\"created\":{\"description\":\"The Unix timestamp (in seconds) of when the chat completion was created. Each chunk has the same timestamp.\",\"type\":\"integer\"},\"id\":{\"description\":\"A unique identifier for the chat completion. Each chunk has the same ID.\",\"type\":\"string\"},\"model\":{\"description\":\"The model to generate the completion.\",\"type\":\"string\"},\"object\":{\"description\":\"The object type, which is always `chat.completion.chunk`.\",\"enum\":[\"chat.completion.chunk\"],\"type\":\"string\"},\"system_fingerprint\":{\"description\":\"This fingerprint represents the backend configuration that the model runs with.\\nCan be used in conjunction with the `seed` request parameter to understand when backend changes have been made that might impact determinism.\\n\",\"type\":\"string\"},\"x_groq\":{\"$ref\":\"#/components/schemas/XGroq\"}},\"required\":[\"choices\",\"created\",\"id\",\"model\",\"object\"],\"type\":\"object\"},\"CreateEmbeddingRequest\":{\"additionalProperties\":false,\"properties\":{\"encoding_format\":{\"default\":\"float\",\"description\":\"The format to return the embeddings in. Can only be `float` or `base64`.\",\"enum\":[\"float\",\"base64\"],\"example\":\"float\",\"type\":\"string\"},\"input\":{\"description\":\"Input text to embed, encoded as a string or array of tokens. To embed multiple inputs in a single request, pass an array of strings or array of token arrays. The input must not exceed the max input tokens for the model, cannot be an empty string, and any array must be 2048 dimensions or less.\\n\",\"example\":\"The quick brown fox jumped over the lazy dog\",\"oneOf\":[{\"default\":\"\",\"description\":\"The string that will be turned into an embedding.\",\"example\":\"This is a test.\",\"title\":\"string\",\"type\":\"string\"},{\"description\":\"The array of strings that will be turned into an embeddings.\",\"items\":{\"default\":\"\",\"example\":\"['This is a test.']\",\"type\":\"string\"},\"maxItems\":2048,\"minItems\":1,\"title\":\"array\",\"type\":\"array\"}],\"x-groq-meta\":{\"validator\":\"EmbeddingInput\"}},\"model\":{\"anyOf\":[{\"type\":\"string\"},{\"enum\":[\"nomic-embed-text-v1_5\"],\"type\":\"string\"}],\"description\":\"ID of the model to use.\\n\",\"example\":\"nomic-embed-text-v1_5\"},\"user\":{\"description\":\"A unique identifier representing your end-user, which can help us monitor and detect abuse.\",\"nullable\":true,\"type\":\"string\"}},\"required\":[\"model\",\"input\"],\"type\":\"object\"},\"CreateEmbeddingResponse\":{\"properties\":{\"data\":{\"description\":\"The list of embeddings generated by the model.\",\"items\":{\"$ref\":\"#/components/schemas/Embedding\"},\"type\":\"array\"},\"model\":{\"description\":\"The name of the model used to generate the embedding.\",\"type\":\"string\"},\"object\":{\"description\":\"The object type, which is always \\\"list\\\".\",\"enum\":[\"list\"],\"type\":\"string\"},\"usage\":{\"description\":\"The usage information for the request.\",\"properties\":{\"prompt_tokens\":{\"description\":\"The number of tokens used by the prompt.\",\"type\":\"integer\"},\"total_tokens\":{\"description\":\"The total number of tokens used by the request.\",\"type\":\"integer\"}},\"required\":[\"prompt_tokens\",\"total_tokens\"],\"type\":\"object\"}},\"required\":[\"object\",\"model\",\"data\",\"usage\"],\"type\":\"object\"},\"CreateFileRequest\":{\"additionalProperties\":false,\"properties\":{\"file\":{\"description\":\"The File object (not file name) to be uploaded.\\n\",\"format\":\"binary\",\"type\":\"string\"},\"purpose\":{\"description\":\"The intended purpose of the uploaded file.\\nUse \\\"batch\\\" for [Batch API](/docs/api-reference#batches).\\n\",\"enum\":[\"batch\"],\"type\":\"string\"}},\"required\":[\"file\",\"purpose\"],\"type\":\"object\"},\"CreateSpeechRequest\":{\"additionalProperties\":false,\"properties\":{\"input\":{\"description\":\"The text to generate audio for.\",\"example\":\"The quick brown fox jumped over the lazy dog\",\"type\":\"string\"},\"model\":{\"anyOf\":[{\"type\":\"string\"},{\"enum\":[\"playai-tts\",\"playai-tts-arabic\"],\"type\":\"string\"}],\"description\":\"One of the [available TTS models](/docs/text-to-speech).\\n\",\"example\":\"playai-tts\"},\"response_format\":{\"default\":\"mp3\",\"description\":\"The format of the generated audio. Supported formats are `flac, mp3, mulaw, ogg, wav`.\",\"enum\":[\"flac\",\"mp3\",\"mulaw\",\"ogg\",\"wav\"],\"type\":\"string\"},\"sample_rate\":{\"default\":48000,\"description\":\"The sample rate for generated audio\",\"enum\":[8000,16000,22050,24000,32000,44100,48000],\"example\":48000,\"type\":\"integer\"},\"speed\":{\"default\":1,\"description\":\"The speed of the generated audio.\",\"example\":1,\"maximum\":5,\"minimum\":0.5,\"type\":\"number\"},\"voice\":{\"description\":\"The voice to use when generating the audio. List of voices can be found [here](/docs/text-to-speech).\",\"example\":\"Fritz-PlayAI\",\"type\":\"string\"}},\"required\":[\"model\",\"input\",\"voice\"],\"type\":\"object\"},\"CreateTranscriptionRequest\":{\"additionalProperties\":false,\"oneOf\":[{\"required\":[\"file\"]},{\"required\":[\"url\"]}],\"properties\":{\"file\":{\"description\":\"The audio file object (not file name) to transcribe, in one of these formats: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, or webm.\\nEither a file or a URL must be provided. Note that the file field is not supported in Batch API requests.\\n\",\"format\":\"binary\",\"type\":\"string\"},\"language\":{\"anyOf\":[{\"type\":\"string\"},{\"enum\":[\"en\",\"zh\",\"de\",\"es\",\"ru\",\"ko\",\"fr\",\"ja\",\"pt\",\"tr\",\"pl\",\"ca\",\"nl\",\"ar\",\"sv\",\"it\",\"id\",\"hi\",\"fi\",\"vi\",\"he\",\"uk\",\"el\",\"ms\",\"cs\",\"ro\",\"da\",\"hu\",\"ta\",\"no\",\"th\",\"ur\",\"hr\",\"bg\",\"lt\",\"la\",\"mi\",\"ml\",\"cy\",\"sk\",\"te\",\"fa\",\"lv\",\"bn\",\"sr\",\"az\",\"sl\",\"kn\",\"et\",\"mk\",\"br\",\"eu\",\"is\",\"hy\",\"ne\",\"mn\",\"bs\",\"kk\",\"sq\",\"sw\",\"gl\",\"mr\",\"pa\",\"si\",\"km\",\"sn\",\"yo\",\"so\",\"af\",\"oc\",\"ka\",\"be\",\"tg\",\"sd\",\"gu\",\"am\",\"yi\",\"lo\",\"uz\",\"fo\",\"ht\",\"ps\",\"tk\",\"nn\",\"mt\",\"sa\",\"lb\",\"my\",\"bo\",\"tl\",\"mg\",\"as\",\"tt\",\"haw\",\"ln\",\"ha\",\"ba\",\"jv\",\"su\",\"yue\"],\"type\":\"string\"}],\"description\":\"The language of the input audio. Supplying the input language in [ISO-639-1](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes) format will improve accuracy and latency.\\n\"},\"model\":{\"anyOf\":[{\"type\":\"string\"},{\"enum\":[\"whisper-large-v3\",\"whisper-large-v3-turbo\"],\"type\":\"string\"}],\"description\":\"ID of the model to use. `whisper-large-v3` and `whisper-large-v3-turbo` are currently available.\\n\",\"example\":\"whisper-large-v3-turbo\"},\"prompt\":{\"description\":\"An optional text to guide the model's style or continue a previous audio segment. The [prompt](/docs/speech-text) should match the audio language.\\n\",\"type\":\"string\"},\"response_format\":{\"default\":\"json\",\"description\":\"The format of the transcript output, in one of these options: `json`, `text`, or `verbose_json`.\\n\",\"enum\":[\"json\",\"text\",\"verbose_json\"],\"type\":\"string\"},\"temperature\":{\"default\":0,\"description\":\"The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. If set to 0, the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to automatically increase the temperature until certain thresholds are hit.\\n\",\"type\":\"number\"},\"timestamp_granularities[]\":{\"default\":[\"segment\"],\"description\":\"The timestamp granularities to populate for this transcription. `response_format` must be set `verbose_json` to use timestamp granularities. Either or both of these options are supported: `word`, or `segment`. Note: There is no additional latency for segment timestamps, but generating word timestamps incurs additional latency.\\n\",\"items\":{\"enum\":[\"word\",\"segment\"],\"type\":\"string\"},\"type\":\"array\"},\"url\":{\"description\":\"The audio URL to translate/transcribe (supports Base64URL).\\nEither a file or a URL must be provided. For Batch API requests, the URL field is required since the file field is not supported.\\n\",\"type\":\"string\"}},\"required\":[\"model\"],\"type\":\"object\"},\"CreateTranscriptionResponseJson\":{\"description\":\"Represents a transcription response returned by model, based on the provided input.\",\"properties\":{\"text\":{\"description\":\"The transcribed text.\",\"type\":\"string\"}},\"required\":[\"text\"],\"type\":\"object\"},\"CreateTranscriptionResponseVerboseJson\":{\"description\":\"Represents a verbose json transcription response returned by model, based on the provided input.\",\"properties\":{\"duration\":{\"description\":\"The duration of the input audio.\",\"type\":\"string\"},\"language\":{\"description\":\"The language of the input audio.\",\"type\":\"string\"},\"segments\":{\"description\":\"Segments of the transcribed text and their corresponding details.\",\"items\":{\"$ref\":\"#/components/schemas/TranscriptionSegment\"},\"type\":\"array\"},\"text\":{\"description\":\"The transcribed text.\",\"type\":\"string\"},\"words\":{\"description\":\"Extracted words and their corresponding timestamps.\",\"items\":{\"$ref\":\"#/components/schemas/TranscriptionWord\"},\"type\":\"array\"}},\"required\":[\"language\",\"duration\",\"text\"],\"type\":\"object\"},\"CreateTranslationRequest\":{\"additionalProperties\":false,\"oneOf\":[{\"required\":[\"file\"]},{\"required\":[\"url\"]}],\"properties\":{\"file\":{\"description\":\"The audio file object (not file name) translate, in one of these formats: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, or webm.\\n\",\"format\":\"binary\",\"type\":\"string\"},\"model\":{\"anyOf\":[{\"type\":\"string\"},{\"enum\":[\"whisper-large-v3\",\"whisper-large-v3-turbo\"],\"type\":\"string\"}],\"description\":\"ID of the model to use. `whisper-large-v3` and `whisper-large-v3-turbo` are currently available.\\n\",\"example\":\"whisper-large-v3-turbo\"},\"prompt\":{\"description\":\"An optional text to guide the model's style or continue a previous audio segment. The [prompt](/docs/guides/speech-to-text/prompting) should be in English.\\n\",\"type\":\"string\"},\"response_format\":{\"default\":\"json\",\"description\":\"The format of the transcript output, in one of these options: `json`, `text`, or `verbose_json`.\\n\",\"enum\":[\"json\",\"text\",\"verbose_json\"],\"type\":\"string\"},\"temperature\":{\"default\":0,\"description\":\"The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. If set to 0, the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to automatically increase the temperature until certain thresholds are hit.\\n\",\"type\":\"number\"},\"url\":{\"description\":\"The audio URL to translate/transcribe (supports Base64URL). Either file or url must be provided.\\nWhen using the Batch API only url is supported.\\n\",\"type\":\"string\"}},\"required\":[\"model\"],\"type\":\"object\"},\"CreateTranslationResponseJson\":{\"properties\":{\"text\":{\"type\":\"string\"}},\"required\":[\"text\"],\"type\":\"object\"},\"CreateTranslationResponseVerboseJson\":{\"properties\":{\"duration\":{\"description\":\"The duration of the input audio.\",\"type\":\"string\"},\"language\":{\"description\":\"The language of the output translation (always `english`).\",\"type\":\"string\"},\"segments\":{\"description\":\"Segments of the translated text and their corresponding details.\",\"items\":{\"$ref\":\"#/components/schemas/TranscriptionSegment\"},\"type\":\"array\"},\"text\":{\"description\":\"The translated text.\",\"type\":\"string\"}},\"required\":[\"language\",\"duration\",\"text\"],\"type\":\"object\"},\"DeleteFileResponse\":{\"properties\":{\"deleted\":{\"type\":\"boolean\"},\"id\":{\"type\":\"string\"},\"object\":{\"enum\":[\"file\"],\"type\":\"string\",\"x-stainless-const\":true}},\"required\":[\"id\",\"object\",\"deleted\"],\"type\":\"object\"},\"DeleteModelResponse\":{\"properties\":{\"deleted\":{\"type\":\"boolean\"},\"id\":{\"type\":\"string\"},\"object\":{\"type\":\"string\"}},\"required\":[\"id\",\"object\",\"deleted\"],\"type\":\"object\"},\"Embedding\":{\"description\":\"Represents an embedding vector returned by embedding endpoint.\\n\",\"properties\":{\"embedding\":{\"oneOf\":[{\"description\":\"The embedding vector, which is a list of floats. The length of vector depends on the model as listed in the [embedding guide](/docs/guides/embeddings).\\n\",\"items\":{\"type\":\"number\"},\"type\":\"array\"},{\"description\":\"The embedding vector, which is a base64 encoded string. The length of vector depends on the model as listed in the [embedding guide](/docs/guides/embeddings).\\n\",\"type\":\"string\"}]},\"index\":{\"description\":\"The index of the embedding in the list of embeddings.\",\"type\":\"integer\"},\"object\":{\"description\":\"The object type, which is always \\\"embedding\\\".\",\"enum\":[\"embedding\"],\"type\":\"string\"}},\"required\":[\"index\",\"object\",\"embedding\"],\"type\":\"object\"},\"Error\":{\"properties\":{\"code\":{\"nullable\":true,\"type\":\"string\"},\"message\":{\"type\":\"string\"},\"param\":{\"nullable\":true,\"type\":\"string\"},\"type\":{\"type\":\"string\"}},\"required\":[\"type\",\"message\",\"param\",\"code\"],\"type\":\"object\"},\"ErrorResponse\":{\"properties\":{\"error\":{\"$ref\":\"#/components/schemas/Error\"}},\"required\":[\"error\"],\"type\":\"object\"},\"File\":{\"description\":\"The `File` object represents a document that has been uploaded.\",\"properties\":{\"bytes\":{\"description\":\"The size of the file, in bytes.\",\"type\":\"integer\"},\"created_at\":{\"description\":\"The Unix timestamp (in seconds) for when the file was created.\",\"type\":\"integer\"},\"filename\":{\"description\":\"The name of the file.\",\"type\":\"string\"},\"id\":{\"description\":\"The file identifier, which can be referenced in the API endpoints.\",\"type\":\"string\"},\"object\":{\"description\":\"The object type, which is always `file`.\",\"enum\":[\"file\"],\"type\":\"string\",\"x-stainless-const\":true},\"purpose\":{\"description\":\"The intended purpose of the file. Supported values are `batch`, and `batch_output`.\",\"enum\":[\"batch\",\"batch_output\"],\"type\":\"string\"}},\"title\":\"File\"},\"FunctionObject\":{\"properties\":{\"description\":{\"description\":\"A description of what the function does, used by the model to choose when and how to call the function.\",\"type\":\"string\"},\"name\":{\"description\":\"The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 64.\",\"type\":\"string\"},\"parameters\":{\"$ref\":\"#/components/schemas/FunctionParameters\"}},\"required\":[\"name\"],\"type\":\"object\"},\"FunctionParameters\":{\"additionalProperties\":true,\"description\":\"The parameters the functions accepts, described as a JSON Schema object. See the docs on [tool use](/docs/tool-use) for examples, and the [JSON Schema reference](https://json-schema.org/understanding-json-schema/) for documentation about the format. \\n\\nOmitting `parameters` defines a function with an empty parameter list.\",\"type\":\"object\"},\"ListBatchesResponse\":{\"properties\":{\"data\":{\"items\":{\"$ref\":\"#/components/schemas/Batch\"},\"type\":\"array\"},\"object\":{\"enum\":[\"list\"],\"type\":\"string\",\"x-stainless-const\":true}},\"required\":[\"object\",\"data\"],\"type\":\"object\"},\"ListFilesResponse\":{\"properties\":{\"data\":{\"items\":{\"$ref\":\"#/components/schemas/File\"},\"type\":\"array\"},\"object\":{\"enum\":[\"list\"],\"type\":\"string\"}},\"required\":[\"object\",\"data\"],\"type\":\"object\"},\"ListModelsResponse\":{\"properties\":{\"data\":{\"items\":{\"$ref\":\"#/components/schemas/Model\"},\"type\":\"array\"},\"object\":{\"enum\":[\"list\"],\"type\":\"string\"}},\"required\":[\"object\",\"data\"],\"type\":\"object\"},\"Model\":{\"description\":\"Describes an OpenAI model offering that can be used with the API.\",\"properties\":{\"created\":{\"description\":\"The Unix timestamp (in seconds) when the model was created.\",\"type\":\"integer\"},\"id\":{\"description\":\"The model identifier, which can be referenced in the API endpoints.\",\"type\":\"string\"},\"object\":{\"description\":\"The object type, which is always \\\"model\\\".\",\"enum\":[\"model\"],\"type\":\"string\"},\"owned_by\":{\"description\":\"The organization that owns the model.\",\"type\":\"string\"}},\"required\":[\"id\",\"object\",\"created\",\"owned_by\"],\"title\":\"Model\"},\"ResponseFormatJsonObject\":{\"description\":\"JSON object response format. An older method of generating JSON responses. Using `json_schema` is recommended for models that support it. Note that the model will not generate JSON without a system or user message instructing it to do so.\\n\",\"properties\":{\"type\":{\"description\":\"The type of response format being defined. Always `json_object`.\",\"enum\":[\"json_object\"],\"type\":\"string\",\"x-stainless-const\":true}},\"required\":[\"type\"],\"title\":\"JSON object\",\"type\":\"object\"},\"ResponseFormatJsonSchema\":{\"description\":\"JSON Schema response format. Used to generate structured JSON responses.\\n\",\"properties\":{\"json_schema\":{\"description\":\"Structured Outputs configuration options, including a JSON Schema.\\n\",\"properties\":{\"description\":{\"description\":\"A description of what the response format is for, used by the model to determine how to respond in the format.\\n\",\"type\":\"string\"},\"name\":{\"description\":\"The name of the response format. Must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 64.\\n\",\"type\":\"string\"},\"schema\":{\"$ref\":\"#/components/schemas/ResponseFormatJsonSchemaSchema\"},\"strict\":{\"default\":false,\"description\":\"Whether to enable strict schema adherence when generating the output. If set to true, the model will always follow the exact schema defined in the `schema` field. Only a subset of JSON Schema is supported when `strict` is `true`.\\n\",\"nullable\":true,\"type\":\"boolean\"}},\"required\":[\"name\"],\"title\":\"JSON schema\",\"type\":\"object\"},\"type\":{\"description\":\"The type of response format being defined. Always `json_schema`.\",\"enum\":[\"json_schema\"],\"type\":\"string\",\"x-stainless-const\":true}},\"required\":[\"type\",\"json_schema\"],\"title\":\"JSON schema\",\"type\":\"object\"},\"ResponseFormatJsonSchemaSchema\":{\"additionalProperties\":true,\"description\":\"The schema for the response format, described as a JSON Schema object.\\nLearn how to build JSON schemas [here](https://json-schema.org/).\\n\",\"title\":\"JSON schema\",\"type\":\"object\"},\"ResponseFormatText\":{\"description\":\"Default response format. Used to generate text responses.\\n\",\"properties\":{\"type\":{\"description\":\"The type of response format being defined. Always `text`.\",\"enum\":[\"text\"],\"type\":\"string\",\"x-stainless-const\":true}},\"required\":[\"type\"],\"title\":\"Text\",\"type\":\"object\"},\"TranscriptionSegment\":{\"properties\":{\"avg_logprob\":{\"description\":\"Average logprob of the segment. If the value is lower than -1, consider the logprobs failed.\",\"format\":\"float\",\"type\":\"number\"},\"compression_ratio\":{\"description\":\"Compression ratio of the segment. If the value is greater than 2.4, consider the compression failed.\",\"format\":\"float\",\"type\":\"number\"},\"end\":{\"description\":\"End time of the segment in seconds.\",\"format\":\"float\",\"type\":\"number\"},\"id\":{\"description\":\"Unique identifier of the segment.\",\"type\":\"integer\"},\"no_speech_prob\":{\"description\":\"Probability of no speech in the segment. If the value is higher than 1.0 and the `avg_logprob` is below -1, consider this segment silent.\",\"format\":\"float\",\"type\":\"number\"},\"seek\":{\"description\":\"Seek offset of the segment.\",\"type\":\"integer\"},\"start\":{\"description\":\"Start time of the segment in seconds.\",\"format\":\"float\",\"type\":\"number\"},\"temperature\":{\"description\":\"Temperature parameter used for generating the segment.\",\"format\":\"float\",\"type\":\"number\"},\"text\":{\"description\":\"Text content of the segment.\",\"type\":\"string\"},\"tokens\":{\"description\":\"Array of token IDs for the text content.\",\"items\":{\"type\":\"integer\"},\"type\":\"array\"}},\"required\":[\"id\",\"seek\",\"start\",\"end\",\"text\",\"tokens\",\"temperature\",\"avg_logprob\",\"compression_ratio\",\"no_speech_prob\"],\"type\":\"object\"},\"TranscriptionWord\":{\"properties\":{\"end\":{\"description\":\"End time of the word in seconds.\",\"format\":\"float\",\"type\":\"number\"},\"start\":{\"description\":\"Start time of the word in seconds.\",\"format\":\"float\",\"type\":\"number\"},\"word\":{\"description\":\"The text content of the word.\",\"type\":\"string\"}},\"required\":[\"word\",\"start\",\"end\"],\"type\":\"object\"},\"XGroq\":{\"properties\":{\"error\":{\"description\":\"An error string indicating why a stream was stopped early\",\"type\":\"string\"},\"id\":{\"description\":\"A groq request ID which can be used by to refer to a specific request to groq support\\nOnly sent with the first chunk\\n\",\"type\":\"string\"},\"usage\":{\"$ref\":\"#/components/schemas/CompletionUsage\"},\"usage_breakdown\":{\"$ref\":\"#/components/schemas/ChatCompletionUsageBreakdown\"}},\"type\":\"object\"}},\"securitySchemes\":{\"api_key\":{\"bearerFormat\":\"apiKey\",\"scheme\":\"bearer\",\"type\":\"http\"}}},\"info\":{\"contact\":{\"email\":\"support@groq.com\",\"name\":\"Groq Support\"},\"description\":\"Specification of the Groq cloud API\",\"termsOfService\":\"https://groq.com/terms-of-use/\",\"title\":\"GroqCloud API Swagger\",\"version\":\"2.1\"},\"openapi\":\"3.0.1\",\"paths\":{\"/openai/v1/audio/speech\":{\"post\":{\"operationId\":\"createSpeech\",\"requestBody\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateSpeechRequest\"}}},\"required\":true},\"responses\":{\"200\":{\"content\":{\"audio/wav\":{\"schema\":{\"format\":\"binary\",\"type\":\"string\"}}},\"description\":\"OK\",\"headers\":{\"Transfer-Encoding\":{\"description\":\"chunked\",\"schema\":{\"type\":\"string\"}}}}},\"summary\":\"Generates audio from the input text.\",\"tags\":[\"Audio\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/audio/speech \\\\\\n -H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n -H \\\"Content-Type: application/json\\\" \\\\\\n -d '{\\n \\\"model\\\": \\\"playai-tts\\\",\\n \\\"input\\\": \\\"I love building and shipping new features for our users!\\\",\\n \\\"voice\\\": \\\"Fritz-PlayAI\\\",\\n \\\"response_format\\\": \\\"wav\\\"\\n }'\\n\",\"js\":\"import fs from \\\"fs\\\";\\nimport path from \\\"path\\\";\\nimport Groq from 'groq-sdk';\\n\\nconst groq = new Groq({\\n apiKey: process.env.GROQ_API_KEY\\n});\\n\\nconst speechFilePath = \\\"speech.wav\\\";\\nconst model = \\\"playai-tts\\\";\\nconst voice = \\\"Fritz-PlayAI\\\";\\nconst text = \\\"I love building and shipping new features for our users!\\\";\\nconst responseFormat = \\\"wav\\\";\\n\\nasync function main() {\\n const response = await groq.audio.speech.create({\\n model: model,\\n voice: voice,\\n input: text,\\n response_format: responseFormat\\n });\\n\\n const buffer = Buffer.from(await response.arrayBuffer());\\n await fs.promises.writeFile(speechFilePath, buffer);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\nfrom groq import Groq\\n\\nclient = Groq(api_key=os.environ.get(\\\"GROQ_API_KEY\\\"))\\n\\nspeech_file_path = \\\"speech.wav\\\"\\nmodel = \\\"playai-tts\\\"\\nvoice = \\\"Fritz-PlayAI\\\"\\ntext = \\\"I love building and shipping new features for our users!\\\"\\nresponse_format = \\\"wav\\\"\\n\\nresponse = client.audio.speech.create(\\n model=model,\\n voice=voice,\\n input=text,\\n response_format=response_format\\n)\\n\\nresponse.write_to_file(speech_file_path)\\n\"},\"title\":\"Default\"}],\"returns\":\"Returns an audio file in `wav` format.\"}}},\"/openai/v1/audio/transcriptions\":{\"post\":{\"operationId\":\"createTranscription\",\"requestBody\":{\"content\":{\"multipart/form-data\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateTranscriptionRequest\"}}},\"required\":true},\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateTranscriptionResponseJson\"}}},\"description\":\"OK\"}},\"summary\":\"Transcribes audio into the input language.\",\"tags\":[\"Audio\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/audio/transcriptions \\\\\\n -H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n -H \\\"Content-Type: multipart/form-data\\\" \\\\\\n -F file=\\\"@./sample_audio.m4a\\\" \\\\\\n -F model=\\\"whisper-large-v3\\\"\\n\",\"js\":\"import fs from \\\"fs\\\";\\nimport Groq from \\\"groq-sdk\\\";\\n\\nconst groq = new Groq();\\nasync function main() {\\n const transcription = await groq.audio.transcriptions.create({\\n file: fs.createReadStream(\\\"sample_audio.m4a\\\"),\\n model: \\\"whisper-large-v3\\\",\\n prompt: \\\"Specify context or spelling\\\", // Optional\\n response_format: \\\"json\\\", // Optional\\n language: \\\"en\\\", // Optional\\n temperature: 0.0, // Optional\\n });\\n console.log(transcription.text);\\n}\\nmain();\\n\",\"py\":\"import os\\nfrom groq import Groq\\n\\nclient = Groq()\\nfilename = os.path.dirname(__file__) + \\\"/sample_audio.m4a\\\"\\n\\nwith open(filename, \\\"rb\\\") as file:\\n transcription = client.audio.transcriptions.create(\\n file=(filename, file.read()),\\n model=\\\"whisper-large-v3\\\",\\n prompt=\\\"Specify context or spelling\\\", # Optional\\n response_format=\\\"json\\\", # Optional\\n language=\\\"en\\\", # Optional\\n temperature=0.0 # Optional\\n )\\n print(transcription.text)\\n\"},\"response\":\"{\\n \\\"text\\\": \\\"Your transcribed text appears here...\\\",\\n \\\"x_groq\\\": {\\n \\\"id\\\": \\\"req_unique_id\\\"\\n }\\n}\\n\",\"title\":\"Default\"}],\"returns\":\"Returns an audio transcription object.\"}}},\"/openai/v1/audio/translations\":{\"post\":{\"operationId\":\"createTranslation\",\"requestBody\":{\"content\":{\"multipart/form-data\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateTranslationRequest\"}}},\"required\":true},\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateTranslationResponseJson\"}},\"text/plain\":{\"schema\":{\"type\":\"string\"}}},\"description\":\"OK\"}},\"summary\":\"Translates audio into English.\",\"tags\":[\"Audio\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/audio/translations \\\\\\n -H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n -H \\\"Content-Type: multipart/form-data\\\" \\\\\\n -F file=\\\"@./sample_audio.m4a\\\" \\\\\\n -F model=\\\"whisper-large-v3\\\"\\n\",\"js\":\"// Default\\nimport fs from \\\"fs\\\";\\nimport Groq from \\\"groq-sdk\\\";\\n\\nconst groq = new Groq();\\nasync function main() {\\n const translation = await groq.audio.translations.create({\\n file: fs.createReadStream(\\\"sample_audio.m4a\\\"),\\n model: \\\"whisper-large-v3\\\",\\n prompt: \\\"Specify context or spelling\\\", // Optional\\n response_format: \\\"json\\\", // Optional\\n temperature: 0.0, // Optional\\n });\\n console.log(translation.text);\\n}\\nmain();\\n\",\"py\":\"# Default\\nimport os\\nfrom groq import Groq\\n\\nclient = Groq()\\nfilename = os.path.dirname(__file__) + \\\"/sample_audio.m4a\\\"\\n\\nwith open(filename, \\\"rb\\\") as file:\\n translation = client.audio.translations.create(\\n file=(filename, file.read()),\\n model=\\\"whisper-large-v3\\\",\\n prompt=\\\"Specify context or spelling\\\", # Optional\\n response_format=\\\"json\\\", # Optional\\n temperature=0.0 # Optional\\n )\\n print(translation.text)\\n\"},\"response\":\"{\\n \\\"text\\\": \\\"Your translated text appears here...\\\",\\n \\\"x_groq\\\": {\\n \\\"id\\\": \\\"req_unique_id\\\"\\n }\\n}\\n\",\"title\":\"Default\"}],\"returns\":\"Returns an audio translation object.\"}}},\"/openai/v1/batches\":{\"get\":{\"operationId\":\"listBatches\",\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ListBatchesResponse\"}}},\"description\":\"Batch listed successfully.\"}},\"summary\":\"List your organization's batches.\",\"tags\":[\"Batch\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/batches \\\\\\n -H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n -H \\\"Content-Type: application/json\\\"\\n\",\"js\":\"import Groq from 'groq-sdk';\\n\\nconst client = new Groq({\\n apiKey: process.env['GROQ_API_KEY'], // This is the default and can be omitted\\n});\\n\\nasync function main() {\\n const batchList = await client.batches.list();\\n console.log(batchList.data);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\nfrom groq import Groq\\n\\nclient = Groq(\\n api_key=os.environ.get(\\\"GROQ_API_KEY\\\"), # This is the default and can be omitted\\n)\\nbatch_list = client.batches.list()\\nprint(batch_list.data)\\n\"},\"response\":\"{\\n \\\"object\\\": \\\"list\\\",\\n \\\"data\\\": [\\n {\\n \\\"id\\\": \\\"batch_01jh6xa7reempvjyh6n3yst2zw\\\",\\n \\\"object\\\": \\\"batch\\\",\\n \\\"endpoint\\\": \\\"/v1/chat/completions\\\",\\n \\\"errors\\\": null,\\n \\\"input_file_id\\\": \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n \\\"completion_window\\\": \\\"24h\\\",\\n \\\"status\\\": \\\"validating\\\",\\n \\\"output_file_id\\\": null,\\n \\\"error_file_id\\\": null,\\n \\\"finalizing_at\\\": null,\\n \\\"failed_at\\\": null,\\n \\\"expired_at\\\": null,\\n \\\"cancelled_at\\\": null,\\n \\\"request_counts\\\": {\\n \\\"total\\\": 0,\\n \\\"completed\\\": 0,\\n \\\"failed\\\": 0\\n },\\n \\\"metadata\\\": null,\\n \\\"created_at\\\": 1736472600,\\n \\\"expires_at\\\": 1736559000,\\n \\\"cancelling_at\\\": null,\\n \\\"completed_at\\\": null,\\n \\\"in_progress_at\\\": null\\n }\\n ]\\n}\\n\",\"title\":\"Default\"}],\"returns\":\"A list of batches\"}},\"post\":{\"operationId\":\"createBatch\",\"requestBody\":{\"content\":{\"application/json\":{\"schema\":{\"properties\":{\"completion_window\":{\"description\":\"The time frame within which the batch should be processed. Durations from `24h` to `7d` are supported.\",\"type\":\"string\"},\"endpoint\":{\"description\":\"The endpoint to be used for all requests in the batch. Currently `/v1/chat/completions` is supported.\",\"enum\":[\"/v1/chat/completions\"],\"type\":\"string\"},\"input_file_id\":{\"description\":\"The ID of an uploaded file that contains requests for the new batch.\\n\\nSee [upload file](/docs/api-reference#files-upload) for how to upload a file.\\n\\nYour input file must be formatted as a [JSONL file](/docs/batch), and must be uploaded with the purpose `batch`. The file can be up to 100 MB in size.\\n\",\"type\":\"string\"},\"metadata\":{\"additionalProperties\":{\"type\":\"string\"},\"description\":\"Optional custom metadata for the batch.\",\"nullable\":true,\"type\":\"object\"}},\"required\":[\"input_file_id\",\"endpoint\",\"completion_window\"],\"type\":\"object\"}}},\"required\":true},\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/Batch\"}}},\"description\":\"Batch created successfully.\"}},\"summary\":\"Creates and executes a batch from an uploaded file of requests. [Learn more](/docs/batch).\",\"tags\":[\"Batch\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/batches \\\\\\n -H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n -H \\\"Content-Type: application/json\\\" \\\\\\n -d '{\\n \\\"input_file_id\\\": \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n \\\"endpoint\\\": \\\"/v1/chat/completions\\\",\\n \\\"completion_window\\\": \\\"24h\\\"\\n }'\\n\",\"js\":\"import Groq from 'groq-sdk';\\n\\nconst client = new Groq({\\n apiKey: process.env['GROQ_API_KEY'], // This is the default and can be omitted\\n});\\n\\nasync function main() {\\n const batch = await client.batches.create({\\n completion_window: \\\"24h\\\",\\n endpoint: \\\"/v1/chat/completions\\\",\\n input_file_id: \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n });\\n console.log(batch.id);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\nfrom groq import Groq\\n\\nclient = Groq(\\n api_key=os.environ.get(\\\"GROQ_API_KEY\\\"), # This is the default and can be omitted\\n)\\nbatch = client.batches.create(\\n completion_window=\\\"24h\\\",\\n endpoint=\\\"/v1/chat/completions\\\",\\n input_file_id=\\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n)\\nprint(batch.id)\\n\"},\"response\":\"{\\n \\\"id\\\": \\\"batch_01jh6xa7reempvjyh6n3yst2zw\\\",\\n \\\"object\\\": \\\"batch\\\",\\n \\\"endpoint\\\": \\\"/v1/chat/completions\\\",\\n \\\"errors\\\": null,\\n \\\"input_file_id\\\": \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n \\\"completion_window\\\": \\\"24h\\\",\\n \\\"status\\\": \\\"validating\\\",\\n \\\"output_file_id\\\": null,\\n \\\"error_file_id\\\": null,\\n \\\"finalizing_at\\\": null,\\n \\\"failed_at\\\": null,\\n \\\"expired_at\\\": null,\\n \\\"cancelled_at\\\": null,\\n \\\"request_counts\\\": {\\n \\\"total\\\": 0,\\n \\\"completed\\\": 0,\\n \\\"failed\\\": 0\\n },\\n \\\"metadata\\\": null,\\n \\\"created_at\\\": 1736472600,\\n \\\"expires_at\\\": 1736559000,\\n \\\"cancelling_at\\\": null,\\n \\\"completed_at\\\": null,\\n \\\"in_progress_at\\\": null\\n}\\n\",\"title\":\"Default\"}],\"returns\":\"A created batch object.\"}}},\"/openai/v1/batches/{batch_id}\":{\"get\":{\"operationId\":\"retrieveBatch\",\"parameters\":[{\"description\":\"The ID of the batch to retrieve.\",\"in\":\"path\",\"name\":\"batch_id\",\"required\":true,\"schema\":{\"type\":\"string\"}}],\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/Batch\"}}},\"description\":\"Batch retrieved successfully.\"}},\"summary\":\"Retrieves a batch.\",\"tags\":[\"Batch\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/batches/batch_01jh6xa7reempvjyh6n3yst2zw \\\\\\n -H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n -H \\\"Content-Type: application/json\\\"\\n\",\"js\":\"import Groq from 'groq-sdk';\\n\\nconst client = new Groq({\\n apiKey: process.env['GROQ_API_KEY'], // This is the default and can be omitted\\n});\\n\\nasync function main() {\\n const batch = await client.batches.retrieve(\\\"batch_01jh6xa7reempvjyh6n3yst2zw\\\");\\n console.log(batch.id);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\nfrom groq import Groq\\n\\nclient = Groq(\\n api_key=os.environ.get(\\\"GROQ_API_KEY\\\"), # This is the default and can be omitted\\n)\\nbatch = client.batches.retrieve(\\n \\\"batch_01jh6xa7reempvjyh6n3yst2zw\\\",\\n)\\nprint(batch.id)\\n\"},\"response\":\"{\\n \\\"id\\\": \\\"batch_01jh6xa7reempvjyh6n3yst2zw\\\",\\n \\\"object\\\": \\\"batch\\\",\\n \\\"endpoint\\\": \\\"/v1/chat/completions\\\",\\n \\\"errors\\\": null,\\n \\\"input_file_id\\\": \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n \\\"completion_window\\\": \\\"24h\\\",\\n \\\"status\\\": \\\"validating\\\",\\n \\\"output_file_id\\\": null,\\n \\\"error_file_id\\\": null,\\n \\\"finalizing_at\\\": null,\\n \\\"failed_at\\\": null,\\n \\\"expired_at\\\": null,\\n \\\"cancelled_at\\\": null,\\n \\\"request_counts\\\": {\\n \\\"total\\\": 0,\\n \\\"completed\\\": 0,\\n \\\"failed\\\": 0\\n },\\n \\\"metadata\\\": null,\\n \\\"created_at\\\": 1736472600,\\n \\\"expires_at\\\": 1736559000,\\n \\\"cancelling_at\\\": null,\\n \\\"completed_at\\\": null,\\n \\\"in_progress_at\\\": null\\n}\\n\",\"title\":\"Default\"}],\"returns\":\"A batch object.\"}}},\"/openai/v1/batches/{batch_id}/cancel\":{\"post\":{\"operationId\":\"cancelBatch\",\"parameters\":[{\"description\":\"The ID of the batch to cancel.\",\"in\":\"path\",\"name\":\"batch_id\",\"required\":true,\"schema\":{\"type\":\"string\"}}],\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/Batch\"}}},\"description\":\"Batch cancelled successfully.\"}},\"summary\":\"Cancels a batch.\",\"tags\":[\"Batch\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl -X POST https://api.groq.com/openai/v1/batches/batch_01jh6xa7reempvjyh6n3yst2zw/cancel \\\\\\n -H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n -H \\\"Content-Type: application/json\\\"\\n\",\"js\":\"import Groq from 'groq-sdk';\\n\\nconst client = new Groq({\\n apiKey: process.env['GROQ_API_KEY'], // This is the default and can be omitted\\n});\\n\\nasync function main() {\\n const batch = await client.batches.cancel(\\\"batch_01jh6xa7reempvjyh6n3yst2zw\\\");\\n console.log(batch.id);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\nfrom groq import Groq\\n\\nclient = Groq(\\n api_key=os.environ.get(\\\"GROQ_API_KEY\\\"), # This is the default and can be omitted\\n)\\nbatch = client.batches.cancel(\\n \\\"batch_01jh6xa7reempvjyh6n3yst2zw\\\",\\n)\\nprint(batch.id)\\n\"},\"response\":\"{\\n \\\"id\\\": \\\"batch_01jh6xa7reempvjyh6n3yst2zw\\\",\\n \\\"object\\\": \\\"batch\\\",\\n \\\"endpoint\\\": \\\"/v1/chat/completions\\\",\\n \\\"errors\\\": null,\\n \\\"input_file_id\\\": \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n \\\"completion_window\\\": \\\"24h\\\",\\n \\\"status\\\": \\\"cancelling\\\",\\n \\\"output_file_id\\\": null,\\n \\\"error_file_id\\\": null,\\n \\\"finalizing_at\\\": null,\\n \\\"failed_at\\\": null,\\n \\\"expired_at\\\": null,\\n \\\"cancelled_at\\\": null,\\n \\\"request_counts\\\": {\\n \\\"total\\\": 0,\\n \\\"completed\\\": 0,\\n \\\"failed\\\": 0\\n },\\n \\\"metadata\\\": null,\\n \\\"created_at\\\": 1736472600,\\n \\\"expires_at\\\": 1736559000,\\n \\\"cancelling_at\\\": null,\\n \\\"completed_at\\\": null,\\n \\\"in_progress_at\\\": null\\n}\\n\",\"title\":\"Default\"}],\"returns\":\"A batch object.\"}}},\"/openai/v1/chat/completions\":{\"post\":{\"operationId\":\"createChatCompletion\",\"requestBody\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateChatCompletionRequest\"}}},\"description\":\"The chat prompt and parameters\",\"required\":true},\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateChatCompletionResponse\"}}},\"description\":\"OK\"}},\"summary\":\"Creates a model response for the given chat conversation.\",\"tags\":[\"Chat\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/chat/completions -s \\\\\\n-H \\\"Content-Type: application/json\\\" \\\\\\n-H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n-d '{\\n \\\"model\\\": \\\"llama-3.3-70b-versatile\\\",\\n \\\"messages\\\": [{\\n \\\"role\\\": \\\"user\\\",\\n \\\"content\\\": \\\"Explain the importance of fast language models\\\"\\n }]\\n}'\\n\",\"js\":\"import Groq from \\\"groq-sdk\\\";\\n\\nconst groq = new Groq({ apiKey: process.env.GROQ_API_KEY });\\n\\nasync function main() {\\n const completion = await groq.chat.completions\\n .create({\\n messages: [\\n {\\n role: \\\"user\\\",\\n content: \\\"Explain the importance of fast language models\\\",\\n },\\n ],\\n model: \\\"llama-3.3-70b-versatile\\\",\\n })\\n console.log(completion.choices[0].message.content);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\n\\nfrom groq import Groq\\n\\nclient = Groq(\\n # This is the default and can be omitted\\n api_key=os.environ.get(\\\"GROQ_API_KEY\\\"),\\n)\\n\\nchat_completion = client.chat.completions.create(\\n messages=[\\n {\\n \\\"role\\\": \\\"system\\\",\\n \\\"content\\\": \\\"You are a helpful assistant.\\\"\\n },\\n {\\n \\\"role\\\": \\\"user\\\",\\n \\\"content\\\": \\\"Explain the importance of fast language models\\\",\\n }\\n ],\\n model=\\\"llama-3.3-70b-versatile\\\",\\n)\\n\\nprint(chat_completion.choices[0].message.content)\\n\"},\"response\":\"$21\",\"title\":\"Default\"}],\"returns\":\"Returns a [chat completion](/docs/api-reference#chat-create) object, or a streamed sequence of [chat completion chunk](/docs/api-reference#chat-create) objects if the request is streamed.\"}}},\"/openai/v1/embeddings\":{\"post\":{\"operationId\":\"createEmbedding\",\"requestBody\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateEmbeddingRequest\"}}},\"required\":true},\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateEmbeddingResponse\"}}},\"description\":\"OK\"}},\"summary\":\"Creates an embedding vector representing the input text.\",\"tags\":[\"Embeddings\"]}},\"/openai/v1/files\":{\"get\":{\"operationId\":\"listFiles\",\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ListFilesResponse\"}}},\"description\":\"OK\"}},\"summary\":\"Returns a list of files.\",\"tags\":[\"Files\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/files \\\\\\n -H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n -H \\\"Content-Type: application/json\\\"\\n\",\"js\":\"import Groq from 'groq-sdk';\\n\\nconst client = new Groq({\\n apiKey: process.env['GROQ_API_KEY'], // This is the default and can be omitted\\n});\\n\\nasync function main() {\\n const fileList = await client.files.list();\\n console.log(fileList.data);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\nfrom groq import Groq\\n\\nclient = Groq(\\n api_key=os.environ.get(\\\"GROQ_API_KEY\\\"), # This is the default and can be omitted\\n)\\nfile_list = client.files.list()\\nprint(file_list.data)\\n\"},\"response\":\"{\\n \\\"object\\\": \\\"list\\\",\\n \\\"data\\\": [\\n {\\n \\\"id\\\": \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n \\\"object\\\": \\\"file\\\",\\n \\\"bytes\\\": 966,\\n \\\"created_at\\\": 1736472501,\\n \\\"filename\\\": \\\"batch_file.jsonl\\\",\\n \\\"purpose\\\": \\\"batch\\\"\\n }\\n ]\\n}\\n\",\"title\":\"Default\"}],\"returns\":\"A list of [File](/docs/api-reference#files-upload) objects.\"}},\"post\":{\"operationId\":\"uploadFile\",\"requestBody\":{\"content\":{\"multipart/form-data\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateFileRequest\"}}},\"required\":true},\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/File\"}}},\"description\":\"OK\"}},\"summary\":\"Upload a file that can be used across various endpoints.\\n\\nThe Batch API only supports `.jsonl` files up to 100 MB in size. The input also has a specific required [format](/docs/batch).\\n\\nPlease contact us if you need to increase these storage limits.\\n\",\"tags\":[\"Files\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/files \\\\\\n -H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n -F purpose=\\\"batch\\\" \\\\\\n -F \\\"file=@batch_file.jsonl\\\"\\n\",\"js\":\"import Groq from 'groq-sdk';\\n\\nconst client = new Groq({\\n apiKey: process.env['GROQ_API_KEY'], // This is the default and can be omitted\\n});\\n\\nconst fileContent = '{\\\"custom_id\\\": \\\"request-1\\\", \\\"method\\\": \\\"POST\\\", \\\"url\\\": \\\"/v1/chat/completions\\\", \\\"body\\\": {\\\"model\\\": \\\"llama-3.1-8b-instant\\\", \\\"messages\\\": [{\\\"role\\\": \\\"user\\\", \\\"content\\\": \\\"Explain the importance of fast language models\\\"}]}}\\\\n';\\n\\nasync function main() {\\n const blob = new Blob([fileContent]);\\n const file = new File([blob], 'batch.jsonl');\\n\\n const createdFile = await client.files.create({ file: file, purpose: 'batch' });\\n console.log(createdFile.id);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\nimport requests # pip install requests first!\\n\\ndef upload_file_to_groq(api_key, file_path):\\n url = \\\"https://api.groq.com/openai/v1/files\\\"\\n\\n headers = {\\n \\\"Authorization\\\": f\\\"Bearer {api_key}\\\"\\n }\\n\\n # Prepare the file and form data\\n files = {\\n \\\"file\\\": (\\\"batch_file.jsonl\\\", open(file_path, \\\"rb\\\"))\\n }\\n\\n data = {\\n \\\"purpose\\\": \\\"batch\\\"\\n }\\n\\n # Make the POST request\\n response = requests.post(url, headers=headers, files=files, data=data)\\n\\n return response.json()\\n\\n# Usage example\\napi_key = os.environ.get(\\\"GROQ_API_KEY\\\")\\nfile_path = \\\"batch_file.jsonl\\\" # Path to your JSONL file\\n\\ntry:\\n result = upload_file_to_groq(api_key, file_path)\\n print(result)\\nexcept Exception as e:\\n print(f\\\"Error: {e}\\\")\\n\"},\"response\":\"{\\n \\\"id\\\": \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n \\\"object\\\": \\\"file\\\",\\n \\\"bytes\\\": 966,\\n \\\"created_at\\\": 1736472501,\\n \\\"filename\\\": \\\"batch_file.jsonl\\\",\\n \\\"purpose\\\": \\\"batch\\\"\\n}\\n\",\"title\":\"Default\"}],\"returns\":\"The uploaded File object.\"}}},\"/openai/v1/files/{file_id}\":{\"delete\":{\"operationId\":\"deleteFile\",\"parameters\":[{\"description\":\"The ID of the file to use for this request.\",\"in\":\"path\",\"name\":\"file_id\",\"required\":true,\"schema\":{\"type\":\"string\"}}],\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/DeleteFileResponse\"}}},\"description\":\"OK\"}},\"summary\":\"Delete a file.\",\"tags\":[\"Files\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl -X DELETE https://api.groq.com/openai/v1/files/file_01jh6x76wtemjr74t1fh0faj5t \\\\\\n -H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n -H \\\"Content-Type: application/json\\\"\\n\",\"js\":\"import Groq from 'groq-sdk';\\n\\nconst client = new Groq({\\n apiKey: process.env['GROQ_API_KEY'], // This is the default and can be omitted\\n});\\n\\nasync function main() {\\n const fileDelete = await client.files.delete(\\\"file_01jh6x76wtemjr74t1fh0faj5t\\\");\\n console.log(fileDelete);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\nfrom groq import Groq\\n\\nclient = Groq(\\n api_key=os.environ.get(\\\"GROQ_API_KEY\\\"), # This is the default and can be omitted\\n)\\nfile_delete = client.files.delete(\\n \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n)\\nprint(file_delete)\\n\"},\"response\":\"{\\n \\\"id\\\": \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n \\\"object\\\": \\\"file\\\",\\n \\\"deleted\\\": true\\n}\\n\",\"title\":\"Default\"}],\"returns\":\"A deleted file response object.\"}},\"get\":{\"operationId\":\"retrieveFile\",\"parameters\":[{\"description\":\"The file to retrieve\",\"in\":\"path\",\"name\":\"file_id\",\"required\":true,\"schema\":{\"type\":\"string\"}}],\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/File\"}}},\"description\":\"OK\"}},\"summary\":\"Returns information about a file.\",\"tags\":[\"Files\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/files/file_01jh6x76wtemjr74t1fh0faj5t \\\\\\n -H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n -H \\\"Content-Type: application/json\\\"\\n\",\"js\":\"import Groq from 'groq-sdk';\\n\\nconst client = new Groq({\\n apiKey: process.env['GROQ_API_KEY'], // This is the default and can be omitted\\n});\\n\\nasync function main() {\\n const file = await client.files.info('file_01jh6x76wtemjr74t1fh0faj5t');\\n console.log(file);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\nfrom groq import Groq\\n\\nclient = Groq(\\n api_key=os.environ.get(\\\"GROQ_API_KEY\\\"), # This is the default and can be omitted\\n)\\nfile = client.files.info(\\n \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n)\\nprint(file)\\n\"},\"response\":\"{\\n \\\"id\\\": \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n \\\"object\\\": \\\"file\\\",\\n \\\"bytes\\\": 966,\\n \\\"created_at\\\": 1736472501,\\n \\\"filename\\\": \\\"batch_file.jsonl\\\",\\n \\\"purpose\\\": \\\"batch\\\"\\n}\\n\",\"title\":\"Default\"}],\"returns\":\"A file object.\"}}},\"/openai/v1/files/{file_id}/content\":{\"get\":{\"operationId\":\"downloadFile\",\"parameters\":[{\"description\":\"The ID of the file to use for this request.\",\"in\":\"path\",\"name\":\"file_id\",\"required\":true,\"schema\":{\"type\":\"string\"}}],\"responses\":{\"200\":{\"content\":{\"application/octet-stream\":{\"schema\":{\"format\":\"binary\",\"type\":\"string\"}}},\"description\":\"OK\"}},\"summary\":\"Returns the contents of the specified file.\",\"tags\":[\"Files\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/files/file_01jh6x76wtemjr74t1fh0faj5t/content \\\\\\n -H \\\"Authorization: Bearer $GROQ_API_KEY\\\" \\\\\\n -H \\\"Content-Type: application/json\\\"\\n\",\"js\":\"import Groq from 'groq-sdk';\\n\\nconst client = new Groq({\\n apiKey: process.env['GROQ_API_KEY'], // This is the default and can be omitted\\n});\\n\\nasync function main() {\\n const response = await client.files.content('file_01jh6x76wtemjr74t1fh0faj5t');\\n console.log(response);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\nfrom groq import Groq\\n\\nclient = Groq(\\n api_key=os.environ.get(\\\"GROQ_API_KEY\\\"), # This is the default and can be omitted\\n)\\nresponse = client.files.content(\\n \\\"file_01jh6x76wtemjr74t1fh0faj5t\\\",\\n)\\nprint(response)\\n\"},\"title\":\"Default\"}],\"returns\":\"The file content\"}}},\"/openai/v1/models\":{\"get\":{\"description\":\"get all available models\",\"operationId\":\"listModels\",\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ListModelsResponse\"}}},\"description\":\"OK\"}},\"summary\":\"List all available [models](https://console.groq.com/docs/models).\",\"tags\":[\"Models\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/models \\\\\\n-H \\\"Authorization: Bearer $GROQ_API_KEY\\\"\\n\",\"js\":\"import Groq from \\\"groq-sdk\\\";\\n\\nconst groq = new Groq({ apiKey: process.env.GROQ_API_KEY });\\n\\nasync function main() {\\n const models = await groq.models.list();\\n console.log(models);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\nfrom groq import Groq\\n\\nclient = Groq(\\n # This is the default and can be omitted\\n api_key=os.environ.get(\\\"GROQ_API_KEY\\\"),\\n)\\n\\nmodels = client.models.list()\\n\\nprint(models)\\n\"},\"response\":\"$22\",\"title\":\"Default\"}],\"returns\":\"A list of model objects.\"}}},\"/openai/v1/models/{model}\":{\"delete\":{\"description\":\"Delete a model\",\"operationId\":\"deleteModel\",\"parameters\":[{\"description\":\"The model to delete\",\"in\":\"path\",\"name\":\"model\",\"required\":true,\"schema\":{\"type\":\"string\"}}],\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/DeleteModelResponse\"}}},\"description\":\"OK\"}},\"summary\":\"Delete model\",\"tags\":[\"Models\"]},\"get\":{\"description\":\"Get a specific model\",\"operationId\":\"retrieveModel\",\"parameters\":[{\"description\":\"The model to get\",\"in\":\"path\",\"name\":\"model\",\"required\":true,\"schema\":{\"type\":\"string\"}}],\"responses\":{\"200\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/Model\"}}},\"description\":\"OK\"}},\"summary\":\"Get detailed information about a [model](https://console.groq.com/docs/models).\",\"tags\":[\"Models\"],\"x-groq-metadata\":{\"examples\":[{\"request\":{\"curl\":\"curl https://api.groq.com/openai/v1/models/llama-3.3-70b-versatile \\\\\\n-H \\\"Authorization: Bearer $GROQ_API_KEY\\\"\\n\",\"js\":\"import Groq from \\\"groq-sdk\\\";\\n\\nconst groq = new Groq({ apiKey: process.env.GROQ_API_KEY });\\n\\nasync function main() {\\n const model = await groq.models.retrieve(\\\"llama-3.3-70b-versatile\\\");\\n console.log(model);\\n}\\n\\nmain();\\n\",\"py\":\"import os\\nfrom groq import Groq\\n\\nclient = Groq(\\n # This is the default and can be omitted\\n api_key=os.environ.get(\\\"GROQ_API_KEY\\\"),\\n)\\n\\nmodel = client.models.retrieve(\\\"llama-3.3-70b-versatile\\\")\\n\\nprint(model)\\n\"},\"response\":\"{\\n \\\"id\\\": \\\"llama3-8b-8192\\\",\\n \\\"object\\\": \\\"model\\\",\\n \\\"created\\\": 1693721698,\\n \\\"owned_by\\\": \\\"Meta\\\",\\n \\\"active\\\": true,\\n \\\"context_window\\\": 8192,\\n \\\"public_apps\\\": null,\\n \\\"max_completion_tokens\\\": 8192\\n}\\n\",\"title\":\"Default\"}],\"returns\":\"A model object.\"}}}},\"security\":[{\"api_key\":[]}],\"servers\":[{\"url\":\"https://api.groq.com\"}],\"x-groq-metadata\":{\"groups\":[{\"description\":null,\"id\":\"chat\",\"sections\":[{\"key\":\"createChatCompletion\",\"path\":\"create\",\"type\":\"endpoint\"}],\"title\":\"Chat\",\"type\":\"endpoints\"},{\"description\":null,\"id\":\"audio\",\"sections\":[{\"key\":\"createTranscription\",\"path\":\"transcription\",\"type\":\"endpoint\"},{\"key\":\"createTranslation\",\"path\":\"translation\",\"type\":\"endpoint\"},{\"key\":\"createSpeech\",\"path\":\"speech\",\"type\":\"endpoint\"}],\"title\":\"Audio\",\"type\":\"endpoints\"},{\"description\":null,\"id\":\"models\",\"sections\":[{\"key\":\"listModels\",\"path\":\"list\",\"type\":\"endpoint\"},{\"key\":\"retrieveModel\",\"path\":\"retrieve\",\"type\":\"endpoint\"}],\"title\":\"Models\",\"type\":\"endpoints\"},{\"description\":null,\"id\":\"batches\",\"sections\":[{\"key\":\"createBatch\",\"path\":\"create\",\"type\":\"endpoint\"},{\"key\":\"retrieveBatch\",\"path\":\"retrieve\",\"type\":\"endpoint\"},{\"key\":\"listBatches\",\"path\":\"list\",\"type\":\"endpoint\"},{\"key\":\"cancelBatch\",\"path\":\"cancel\",\"type\":\"endpoint\"}],\"title\":\"Batches\",\"type\":\"endpoints\"},{\"description\":null,\"id\":\"files\",\"sections\":[{\"key\":\"uploadFile\",\"path\":\"upload\",\"type\":\"endpoint\"},{\"key\":\"listFiles\",\"path\":\"list\",\"type\":\"endpoint\"},{\"key\":\"deleteFile\",\"path\":\"delete\",\"type\":\"endpoint\"},{\"key\":\"retrieveFile\",\"path\":\"retrieve\",\"type\":\"endpoint\"},{\"key\":\"downloadFile\",\"path\":\"download\",\"type\":\"endpoint\"}],\"title\":\"Files\",\"type\":\"endpoints\"}]}},\"children\":[\"$\",\"$L5\",null,{\"parallelRouterKey\":\"children\",\"error\":\"$undefined\",\"errorStyles\":\"$undefined\",\"errorScripts\":\"$undefined\",\"template\":[\"$\",\"$L6\",null,{}],\"templateStyles\":\"$undefined\",\"templateScripts\":\"$undefined\",\"notFound\":\"$undefined\",\"forbidden\":\"$undefined\",\"unauthorized\":\"$undefined\"}]}]\n"])</script>

<iframe id="intercom-frame" style="position: absolute !important; opacity: 0 !important; width: 1px !important; height: 1px !important; top: 0 !important; left: 0 !important; border: none !important; display: block !important; z-index: -1 !important; pointer-events: none;" aria-hidden="true" tabindex="-1" title="Intercom"></iframe><script id="_next-ga-init" data-nscript="afterInteractive">window['dataLayer'] = window['dataLayer'] || []; function gtag(){window['dataLayer'].push(arguments);} gtag('js', new Date()); gtag('config', 'G-CQ9K0VPEEQ');</script><script src="https://www.googletagmanager.com/gtag/js?id=G-CQ9K0VPEEQ" id="_next-ga" data-nscript="afterInteractive"></script> <script id="_next-gtm-init" data-nscript="afterInteractive"> (function(w,l){ w[l]=w[l]||[]; w[l].push({'gtm.start': new Date().getTime(),event:'gtm.js'}); })(window,'dataLayer');</script><script src="https://www.googletagmanager.com/gtm.js?id=GTM-WWK828JN" id="_next-gtm" data-ntpc="GTM" data-nscript="afterInteractive"></script>

<style id="intercom-lightweight-app-style" type="text/css">@keyframes intercom-lightweight-app-launcher { from { opacity: 0; transform: scale(0.5); } to { opacity: 1; transform: scale(1); } } @keyframes intercom-lightweight-app-gradient { from { opacity: 0; } to { opacity: 1; } } @keyframes intercom-lightweight-app-messenger { 0% { opacity: 0; transform: scale(0); } 40% { opacity: 1; } 100% { transform: scale(1); } } .intercom-lightweight-app { position: fixed; z-index: 2147483001; width: 0; height: 0; font-family: intercom-font, "Helvetica Neue", "Apple Color Emoji", Helvetica, Arial, sans-serif; } .intercom-lightweight-app-gradient { position: fixed; z-index: 2147483002; width: 500px; height: 500px; bottom: 0; right: 0; pointer-events: none; background: radial-gradient( ellipse at bottom right, rgba(29, 39, 54, 0.16) 0%, rgba(29, 39, 54, 0) 72%); animation: intercom-lightweight-app-gradient 200ms ease-out; } .intercom-lightweight-app-launcher { position: fixed; z-index: 2147483003; padding: 0 !important; margin: 0 !important; border: none; bottom: 20px; right: 20px; max-width: 48px; width: 48px; max-height: 48px; height: 48px; border-radius: 50%; background: #F55036; cursor: pointer; box-shadow: 0 1px 6px 0 rgba(0, 0, 0, 0.06), 0 2px 32px 0 rgba(0, 0, 0, 0.16); transition: transform 167ms cubic-bezier(0.33, 0.00, 0.00, 1.00); box-sizing: content-box; } .intercom-lightweight-app-launcher:hover { transition: transform 250ms cubic-bezier(0.33, 0.00, 0.00, 1.00); transform: scale(1.1) } .intercom-lightweight-app-launcher:active { transform: scale(0.85); transition: transform 134ms cubic-bezier(0.45, 0, 0.2, 1); } .intercom-lightweight-app-launcher:focus { outline: none; } .intercom-lightweight-app-launcher-icon { display: flex; align-items: center; justify-content: center; position: absolute; top: 0; left: 0; width: 48px; height: 48px; transition: transform 100ms linear, opacity 80ms linear; } .intercom-lightweight-app-launcher-icon-open { opacity: 1; transform: rotate(0deg) scale(1); } .intercom-lightweight-app-launcher-icon-open svg { width: 24px; height: 24px; } .intercom-lightweight-app-launcher-icon-open svg path { fill: rgb(255, 255, 255); } .intercom-lightweight-app-launcher-icon-self-serve { opacity: 1; transform: rotate(0deg) scale(1); } .intercom-lightweight-app-launcher-icon-self-serve svg { height: 44px; } .intercom-lightweight-app-launcher-icon-self-serve svg path { fill: rgb(255, 255, 255); } .intercom-lightweight-app-launcher-custom-icon-open { max-height: 24px; max-width: 24px; opacity: 1; transform: rotate(0deg) scale(1); } .intercom-lightweight-app-launcher-icon-minimize { opacity: 0; transform: rotate(-60deg) scale(0); } .intercom-lightweight-app-launcher-icon-minimize svg path { fill: rgb(255, 255, 255); } .intercom-lightweight-app-messenger { position: fixed; z-index: 2147483003; overflow: hidden; background-color: #ffffff; animation: intercom-lightweight-app-messenger 250ms cubic-bezier(0, 1, 1, 1); transform-origin: bottom right; width: 400px; height: calc(100% - 40px); max-height: 704px; min-height: 250px; right: 20px; bottom: 20px; box-shadow: 0 5px 40px rgba(0,0,0,0.16); border-radius: 16px; } .intercom-lightweight-app-messenger-header { height: 64px; border-bottom: none; background: #ffffff; } .intercom-lightweight-app-messenger-footer{ position:absolute; bottom:0; width: 100%; height: 80px; background: #ffffff; font-size: 14px; line-height: 21px; border-top: 1px solid rgba(0, 0, 0, 0.05); box-shadow: 0px 0px 25px rgba(0, 0, 0, 0.05); } @media print { .intercom-lightweight-app { display: none; } }</style>

<iframe name="__privateStripeMetricsController8670" frameborder="0" allowtransparency="true" scrolling="no" role="presentation" allow="payment *" src="https://js.stripe.com/v3/m-outer-3437aaddcdf6922d623e172c2d6f9278.html#url=https%3A%2F%2Fconsole.groq.com%2Fdocs%2Fspeech-to-text&amp;title=Speech%20to%20Text%20-%20GroqDocs&amp;referrer=https%3A%2F%2Fconsole.groq.com%2Fhome%3Futm_source%3Dwebsite%26utm_medium%3Doutbound_link%26utm_campaign%3Ddev_console_click&amp;muid=37269dbe-2109-4466-a875-96778b7561a6b68b65&amp;sid=ee9d4dbf-f502-41e1-ae66-9581b0587e5bd6e130&amp;version=6&amp;preview=false&amp;__shared_params__[version]=v3" aria-hidden="true" tabindex="-1" style="border: none !important; margin: 0px !important; padding: 0px !important; width: 1px !important; min-width: 100% !important; overflow: hidden !important; display: block !important; visibility: hidden !important; position: fixed !important; height: 1px !important; pointer-events: none !important; user-select: none !important;"></iframe><iframe name="__privateStripeController8671" frameborder="0" allowtransparency="true" scrolling="no" role="presentation" allow="payment *" src="https://js.stripe.com/v3/controller-with-preconnect-c1a1e2849bb061e674b8f400025b2fca.html#__shared_params__[version]=v3&amp;apiKey=pk_live_51Of9kmEnzmVEg9qP5bfEuBfP8Rq9sHTKFWvsH14oyyTVB6GX3FkOdWJvFpMrtvwbxP6Wg5ZbhFYyIUMpS61vbzla00hbxM1pUA&amp;stripeJsId=f33b983e-8c5d-4d3e-a9b8-fef1d0a1f29d&amp;firstStripeInstanceCreatedLatency=18839&amp;controllerCount=1&amp;isCheckout=false&amp;stripeJsLoadTime=1750279587878&amp;manualBrowserDeprecationRollout=false&amp;mids[guid]=b9c99f80-f03a-4480-93bc-78a575e19ec2ed17d3&amp;mids[muid]=37269dbe-2109-4466-a875-96778b7561a6b68b65&amp;mids[sid]=ee9d4dbf-f502-41e1-ae66-9581b0587e5bd6e130&amp;referrer=https%3A%2F%2Fconsole.groq.com%2Fdocs%2Fspeech-to-text&amp;controllerId=__privateStripeController8671" aria-hidden="true" tabindex="-1" style="border: none !important; margin: 0px !important; padding: 0px !important; width: 1px !important; min-width: 100% !important; overflow: hidden !important; display: block !important; visibility: hidden !important; position: fixed !important; height: 1px !important; pointer-events: none !important; user-select: none !important;"></iframe>

## Embedded Content