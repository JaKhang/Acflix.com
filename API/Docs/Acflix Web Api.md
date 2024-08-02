---
title: Acflix Web Api
language_tabs:
  - shell: Shell
  - http: HTTP
  - javascript: JavaScript
  - ruby: Ruby
  - python: Python
  - php: PHP
  - java: Java
  - go: Go
toc_footers: []
includes: []
search: true
code_clipboard: true
highlight_theme: darkula
headingLevel: 2
generator: "@tarslib/widdershins v4.0.23"

---

# Acflix Web Api

Base URLs:

# Authentication

# Sample APIs

## GET Find pet by ID

GET /pet/{petId}

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|petId|path|string| yes |pet ID|

> Response Examples

> OK

```json
{
  "code": 0,
  "data": {
    "name": "Hello Kitty",
    "photoUrls": [
      "http://dummyimage.com/400x400"
    ],
    "id": 3,
    "category": {
      "id": 71,
      "name": "Cat"
    },
    "tags": [
      {
        "id": 22,
        "name": "Cat"
      }
    ],
    "status": "sold"
  }
}
```

> 400 Response

```json
{
  "code": 0,
  "message": "string"
}
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|Inline|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Invalid input|Inline|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Resource not found|Inline|

### Responses Data Schema

HTTP Status Code **200**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||status code|
|» data|object|true|none||pet details|

HTTP Status Code **400**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» message|string|true|none||none|

HTTP Status Code **404**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» message|string|true|none||none|

## DELETE Deletes a pet

DELETE /pet/{petId}

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|petId|path|string| yes |Pet id to delete|
|api_key|header|string| no |none|

> Response Examples

> OK

```json
{
  "code": 0
}
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|Inline|

### Responses Data Schema

HTTP Status Code **200**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|

## POST Add a new pet to the store

POST /pet

> Body Parameters

```yaml
name: Hello Kitty
status: sold

```

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|body|body|object| no |none|
|» name|body|string| yes |Pet Name|
|» status|body|string| yes |Pet Sales Status|

> Response Examples

> OK

```json
{
  "code": 0,
  "data": {
    "name": "Hello Kitty",
    "photoUrls": [
      "http://dummyimage.com/400x400"
    ],
    "id": 3,
    "category": {
      "id": 71,
      "name": "Cat"
    },
    "tags": [
      {
        "id": 22,
        "name": "Cat"
      }
    ],
    "status": "sold"
  }
}
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|OK|Inline|

### Responses Data Schema

HTTP Status Code **201**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» data|object|true|none||pet details|

## PUT Update an existing pet

PUT /pet

> Body Parameters

```json
{}
```

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|body|body|object| no |none|

> Response Examples

> OK

```json
{
  "code": 0,
  "data": {
    "name": "Hello Kitty",
    "photoUrls": [
      "http://dummyimage.com/400x400"
    ],
    "id": 3,
    "category": {
      "id": 71,
      "name": "Cat"
    },
    "tags": [
      {
        "id": 22,
        "name": "Cat"
      }
    ],
    "status": "sold"
  }
}
```

> 404 Response

```json
{}
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|Inline|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Record not found|Inline|
|405|[Method Not Allowed](https://tools.ietf.org/html/rfc7231#section-6.5.5)|Validation error|Inline|

### Responses Data Schema

HTTP Status Code **200**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» data|object|true|none||pet details|

## GET Finds Pets by status

GET /pet/findByStatus

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|status|query|string| yes |Status values that need to be considered for filter|

> Response Examples

> OK

```json
{
  "code": 0,
  "data": [
    {
      "name": "Hello Kitty",
      "photoUrls": [
        "http://dummyimage.com/400x400"
      ],
      "id": 3,
      "category": {
        "id": 71,
        "name": "Cat"
      },
      "tags": [
        {
          "id": 22,
          "name": "Cat"
        }
      ],
      "status": "sold"
    },
    {
      "name": "White Dog",
      "photoUrls": [
        "http://dummyimage.com/400x400"
      ],
      "id": 3,
      "category": {
        "id": 71,
        "name": "Dog"
      },
      "tags": [
        {
          "id": 22,
          "name": "Dog"
        }
      ],
      "status": "sold"
    }
  ]
}
```

> 400 Response

```json
{
  "code": 0
}
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|Inline|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Invalid status value|Inline|

### Responses Data Schema

HTTP Status Code **400**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|

# Film Api

## GET Get Several Films

GET /films

Get Acflix catalog information for multiple films identified by their Acflix IDs.

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|ids|query|array[string]| no |A comma-separated list of the Acflix IDs for the films. Maximum: 20 IDs.|

> Response Examples

> 200 Response

```json
"string"
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|string|

## GET Get Film

GET /films/{id}

Get Acflix catalog information for a single films.

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|id|path|string| yes |The Acflix Id of films|

> Response Examples

> 200 Response

```json
{
  "id": "ad4123da-7221-4744-9ab2-37f01933c06b",
  "name": "Chú Thuật Hồi Chiến (Phần 2)",
  "originalName": "Jujutsu Kaisen (Season 2)",
  "description": "Vì một lý do kỳ lạ nào đó, nam sinh Itadori Yuuji, mặc dù có thể chất hoàn hảo nhưng lại đâm đầu vào tham gia hội nghiên cứu tâm linh. Vào ngày nọ, hội nghiên cứu có được vật nguyền bị phong ấn và một thành viên đã vô tình mở phong ấn, khiến các thành viên khác lần lượt bị tấn công. Để cứu bạn, Yuuji buộc phải ra tay.",
  "genres": [
    "animation",
    "action"
  ],
  "director": "Park Seong Hu",
  "actors": [
    {
      "id": "ad4123da-7221-4744-9ab2-37f01933c06b",
      "name": "Yuichi Nakamura",
      "images": [
        {
          "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228",
          "width": 300,
          "height": 300
        }
      ]
    }
  ],
  "country": "VN",
  "duration": 0,
  "eposides": [
    {
      "index": 1,
      "label": "Tập 1",
      "name": "Hoài ngọc",
      "sourceId": "ad4123da-7221-4744-9ab2-37f01933c06b"
    }
  ],
  "releaseDate": 2023,
  "releaseDatePrecision": "year",
  "type": "series",
  "restriction": 18,
  "poster": [
    {
      "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228",
      "width": 300,
      "height": 300
    }
  ],
  "cover": [
    {
      "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228",
      "width": 300,
      "height": 300
    }
  ],
  "status": "complete"
}
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[FilmDetils](#schemafilmdetils)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Bad or expired token|[ErrorReponse](#schemaerrorreponse)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Resource not found|Inline|

### Responses Data Schema

HTTP Status Code **404**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» message|string|true|none||none|

## GET Get FIlm Comments

GET /films/{id}/comments

Get Acflix's comments. Optional parameters can be used to limit the number of comments returned.

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|id|path|string| yes |none|
|offset|query|integer| no |The index of the first item to return. Default: 0 (the first item). Use with limit to get the next set of items.|
|limit|query|integer| no |The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.|
|sort|query|string| no |none|

> Response Examples

> 200 Response

```json
{}
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|

### Responses Data Schema

## POST Comment to Film

POST /films/{id}/commnets

Post a comment to current film

> Body Parameters

```json
{
  "content": "This is commnet"
}
```

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|id|path|string| yes |none|
|body|body|[CommentRequest](#schemacommentrequest)| no |none|

> Response Examples

> 201 Response

```json
null
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|Created|null|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Invalid input|Inline|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Bad or expired token|[ErrorReponse](#schemaerrorreponse)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Resource not found|Inline|

### Responses Data Schema

HTTP Status Code **400**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» message|string|true|none||none|

HTTP Status Code **404**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» message|string|true|none||none|

## GET Get User's Saved Films

GET /me/films

Get a list of the films saved in the current Spotify user's 'Your Film' library.

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|offset|query|number| no |The index of the first item to return. Default: 0 (the first item). Use with limit to get the next set of items.|
|limit|query|number| no |The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.|

> Response Examples

> 200 Response

```json
{
  "totalItems": 0,
  "items": [
    {}
  ],
  "isFirst": true,
  "isLast": true,
  "page": 0,
  "limit": 0,
  "totalPage": 0
}
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Invalid input|Inline|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Bad or expired token|[ErrorReponse](#schemaerrorreponse)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Resource not found|Inline|

### Responses Data Schema

HTTP Status Code **200**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» totalItems|number|false|none||none|
|» items|[[Film](#schemafilm)]|false|none||none|
|» isFirst|boolean|false|none||none|
|» isLast|boolean|false|none||none|
|» page|number|false|none||none|
|» limit|number|false|none||none|
|» totalPage|number|false|none||none|

HTTP Status Code **400**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» message|string|true|none||none|

HTTP Status Code **404**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» message|string|true|none||none|

## PUT Save Albums for Current User

PUT /me/films

Save one or more films to the current user's 'Your Films' library.

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|ids|query|array[string]| no |A comma-separated list of the Acflix IDs for the films. Maximum: 20 IDs.|

> Response Examples

> 200 Response

```json
null
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|null|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Invalid input|Inline|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Bad or expired token|[ErrorReponse](#schemaerrorreponse)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Resource not found|Inline|

### Responses Data Schema

HTTP Status Code **400**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» message|string|true|none||none|

HTTP Status Code **404**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» message|string|true|none||none|

## DELETE Remove Users' Saved Films

DELETE /me/films

Remove one or more films from the current user's 'Your Film' library.

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|ids|query|array[string]| no |A comma-separated list of the Acflix IDs for the films. Maximum: 20 IDs.|

> Response Examples

> 200 Response

```json
{}
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Invalid input|Inline|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Bad or expired token|[ErrorReponse](#schemaerrorreponse)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Resource not found|Inline|

### Responses Data Schema

HTTP Status Code **400**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» message|string|true|none||none|

HTTP Status Code **404**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» message|string|true|none||none|

## GET Check User Saved Films

GET /me/films/contains

### Params

|Name|Location|Type|Required|Description|
|---|---|---|---|---|
|ids|query|array[string]| no |A comma-separated list of the Acflix IDs for the films. Maximum: 20 IDs.|

> Response Examples

> 200 Response

```json
null
```

### Responses

|HTTP Status Code |Meaning|Description|Data schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|null|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Invalid input|Inline|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Bad or expired token|[ErrorReponse](#schemaerrorreponse)|

### Responses Data Schema

HTTP Status Code **400**

|Name|Type|Required|Restrictions|Title|description|
|---|---|---|---|---|---|
|» code|integer|true|none||none|
|» message|string|true|none||none|

# Data Schema

<h2 id="tocS_Film">Film</h2>

<a id="schemafilm"></a>
<a id="schema_Film"></a>
<a id="tocSfilm"></a>
<a id="tocsfilm"></a>

```json
{}

```

### Attribute

*None*

<h2 id="tocS_CommentRequest">CommentRequest</h2>

<a id="schemacommentrequest"></a>
<a id="schema_CommentRequest"></a>
<a id="tocScommentrequest"></a>
<a id="tocscommentrequest"></a>

```json
{
  "content": "This is commnet"
}

```

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|content|string|true|none||none|

<h2 id="tocS_VoteRequest">VoteRequest</h2>

<a id="schemavoterequest"></a>
<a id="schema_VoteRequest"></a>
<a id="tocSvoterequest"></a>
<a id="tocsvoterequest"></a>

```json
{
  "vote": 5
}

```

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|vote|number|true|none||none|

<h2 id="tocS_PageResponse">PageResponse</h2>

<a id="schemapageresponse"></a>
<a id="schema_PageResponse"></a>
<a id="tocSpageresponse"></a>
<a id="tocspageresponse"></a>

```json
{
  "totalItems": 0,
  "items": [
    {}
  ],
  "isFirst": true,
  "isLast": true,
  "page": 0,
  "limit": 0,
  "totalPage": 0
}

```

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|totalItems|number|false|none||none|
|items|[object]|false|none||none|
|isFirst|boolean|false|none||none|
|isLast|boolean|false|none||none|
|page|number|false|none||none|
|limit|number|false|none||none|
|totalPage|number|false|none||none|

<h2 id="tocS_Comment">Comment</h2>

<a id="schemacomment"></a>
<a id="schema_Comment"></a>
<a id="tocScomment"></a>
<a id="tocscomment"></a>

```json
{
  "content": "string",
  "user": {
    "id": "ad4123da-7221-4744-9ab2-37f01933c06b",
    "name": "string",
    "avatar": "string"
  },
  "createdAt": 0
}

```

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|content|string|false|none||none|
|user|[SimpleUser](#schemasimpleuser)|false|none||none|
|createdAt|number|false|none||none|

<h2 id="tocS_SimpleUser">SimpleUser</h2>

<a id="schemasimpleuser"></a>
<a id="schema_SimpleUser"></a>
<a id="tocSsimpleuser"></a>
<a id="tocssimpleuser"></a>

```json
{
  "id": "ad4123da-7221-4744-9ab2-37f01933c06b",
  "name": "string",
  "avatar": "string"
}

```

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|id|[ID](#schemaid)|false|none||UUID|
|name|string|false|none||none|
|avatar|string|false|none||none|

<h2 id="tocS_ErrorReponse">ErrorReponse</h2>

<a id="schemaerrorreponse"></a>
<a id="schema_ErrorReponse"></a>
<a id="tocSerrorreponse"></a>
<a id="tocserrorreponse"></a>

```json
{
  "status": 404,
  "message": "Resouse not found"
}

```

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|status|number|true|none||status|
|message|string|true|none||none|

<h2 id="tocS_Episode">Episode</h2>

<a id="schemaepisode"></a>
<a id="schema_Episode"></a>
<a id="tocSepisode"></a>
<a id="tocsepisode"></a>

```json
{
  "index": 1,
  "label": "Tập 1",
  "name": "Hoài ngọc",
  "sourceId": "ad4123da-7221-4744-9ab2-37f01933c06b"
}

```

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|index|number|false|none||index of episode|
|label|string|false|none||lable|
|name|string|false|none||none|
|sourceId|[ID](#schemaid)|false|none||UUID|

<h2 id="tocS_FilmType">FilmType</h2>

<a id="schemafilmtype"></a>
<a id="schema_FilmType"></a>
<a id="tocSfilmtype"></a>
<a id="tocsfilmtype"></a>

```json
"series"

```

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|*anonymous*|string|false|none||none|

#### Enum

|Name|Value|
|---|---|
|*anonymous*|series|
|*anonymous*|movie|

<h2 id="tocS_FilmDetils">FilmDetils</h2>

<a id="schemafilmdetils"></a>
<a id="schema_FilmDetils"></a>
<a id="tocSfilmdetils"></a>
<a id="tocsfilmdetils"></a>

```json
{
  "id": "ad4123da-7221-4744-9ab2-37f01933c06b",
  "name": "Chú Thuật Hồi Chiến (Phần 2)",
  "originalName": "Jujutsu Kaisen (Season 2)",
  "description": "Vì một lý do kỳ lạ nào đó, nam sinh Itadori Yuuji, mặc dù có thể chất hoàn hảo nhưng lại đâm đầu vào tham gia hội nghiên cứu tâm linh. Vào ngày nọ, hội nghiên cứu có được vật nguyền bị phong ấn và một thành viên đã vô tình mở phong ấn, khiến các thành viên khác lần lượt bị tấn công. Để cứu bạn, Yuuji buộc phải ra tay.",
  "genres": [
    "animation",
    "action"
  ],
  "director": "Park Seong Hu",
  "actors": [
    {
      "id": "ad4123da-7221-4744-9ab2-37f01933c06b",
      "name": "Yuichi Nakamura",
      "images": [
        {
          "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228",
          "width": 300,
          "height": 300
        }
      ]
    }
  ],
  "country": "VN",
  "duration": 0,
  "eposides": [
    {
      "index": 1,
      "label": "Tập 1",
      "name": "Hoài ngọc",
      "sourceId": "ad4123da-7221-4744-9ab2-37f01933c06b"
    }
  ],
  "releaseDate": 2023,
  "releaseDatePrecision": "year",
  "type": "series",
  "restriction": 18,
  "poster": [
    {
      "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228",
      "width": 300,
      "height": 300
    }
  ],
  "cover": [
    {
      "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228",
      "width": 300,
      "height": 300
    }
  ],
  "status": "complete"
}

```

Full film information

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|id|[ID](#schemaid)|false|none||UUID|
|name|string|false|none||The name of the film empty if film takedown|
|originalName|string|false|none||The English Name of the film|
|description|string|false|none||none|
|genres|[[Genre](#schemagenre)]|false|none||The array of genre|
|director|string|false|none||The name of the director|
|actors|[[Actor](#schemaactor)]|false|none||none|
|country|string|false|none||An ISO 3166-1 alpha-2 country code. If a country code is specified|
|duration|number|false|none||duration of film if series is duration per eposide|
|eposides|[[Episode](#schemaepisode)]|false|none||Total released eposide empty if film is movie|
|releaseDate|string|false|none||none|
|releaseDatePrecision|string|false|none||none|
|type|[FilmType](#schemafilmtype)|false|none||none|
|restriction|number|false|none||none|
|poster|[[Image](#schemaimage)]|false|none||Cover art with 2x3 some size|
|cover|[[Image](#schemaimage)]|false|none||Cover art with 3x2 some size|
|status|string|false|none||status|

#### Enum

|Name|Value|
|---|---|
|releaseDatePrecision|day|
|releaseDatePrecision|month|
|releaseDatePrecision|year|
|status|released|
|status|pending|
|status|complete|

<h2 id="tocS_ID">ID</h2>

<a id="schemaid"></a>
<a id="schema_ID"></a>
<a id="tocSid"></a>
<a id="tocsid"></a>

```json
"ad4123da-7221-4744-9ab2-37f01933c06b"

```

UUID

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|*anonymous*|string|false|none||UUID|

<h2 id="tocS_Actor">Actor</h2>

<a id="schemaactor"></a>
<a id="schema_Actor"></a>
<a id="tocSactor"></a>
<a id="tocsactor"></a>

```json
{
  "id": "ad4123da-7221-4744-9ab2-37f01933c06b",
  "name": "Yuichi Nakamura",
  "images": [
    {
      "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228",
      "width": 300,
      "height": 300
    }
  ]
}

```

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|id|[ID](#schemaid)|false|none||UUID|
|name|string|false|none||none|
|images|[[Image](#schemaimage)]|false|none||Avatar of atcor|

<h2 id="tocS_Genre">Genre</h2>

<a id="schemagenre"></a>
<a id="schema_Genre"></a>
<a id="tocSgenre"></a>
<a id="tocsgenre"></a>

```json
"animation"

```

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|*anonymous*|string|false|none||none|

#### Enum

|Name|Value|
|---|---|
|*anonymous*|action|
|*anonymous*|adventure|
|*anonymous*|comedy|
|*anonymous*|drama|
|*anonymous*|horror|
|*anonymous*|romance|
|*anonymous*|scfi|
|*anonymous*|fantasy|
|*anonymous*|history|
|*anonymous*|crime|
|*anonymous*|animation|
|*anonymous*|mystery|
|*anonymous*|thriller|
|*anonymous*|documentory|
|*anonymous*|musical|
|*anonymous*|sport|
|*anonymous*|war|
|*anonymous*|family|
|*anonymous*|western|
|*anonymous*|biography|

<h2 id="tocS_Image">Image</h2>

<a id="schemaimage"></a>
<a id="schema_Image"></a>
<a id="tocSimage"></a>
<a id="tocsimage"></a>

```json
{
  "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228",
  "width": 300,
  "height": 300
}

```

The cover art for the album in various sizes, widest first.

### Attribute

|Name|Type|Required|Restrictions|Title|Description|
|---|---|---|---|---|---|
|url|string|false|none||The source URL of the image.|
|width|number|false|none||none|
|height|number|false|none||none|

