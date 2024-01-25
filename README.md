# Gerenciar arquivos usando armazenamento de blobs da Azure

Uma poc que busca arquivos, exclui, verifica se existe e faz o upload de arquivos usando o armazenamento de blobs da azure.

## Documenta��o da API

#### Retorna o arquivo para download

```http
  GET /api/v1/files?file-path=/nomeDaPasta/nomeDoArquivo
```

| Par�metro   | Tipo       | Descri��o                           |
| :---------- | :--------- | :---------------------------------- |
| `file-path` | `string` | **Obrigat�rio**. Caminho onde o arquivo se encontra e o nome da pasta |

#### Retorna se o arquivo existe

```http
  GET /api/v1/files/exist?file-path=/nomeDaPasta/nomeDoArquivo
```

| Par�metro   | Tipo       | Descri��o                                   |
| :---------- | :--------- | :------------------------------------------ |
| `file-path`      | `string` | **Obrigat�rio**. Caminho onde o arquivo se encontra e o nome da pasta |

#### Deleta o arquivo se existe

```http
  curl --location --request DELETE '/api/v1/files' \
  --header 'accept: */*' \
  --header 'Content-Type: application/json' \
  --data '{ "filePath": "/nomeDaPasta/nomeDoArquivo" }'
```

| Par�metro   | Tipo       | Descri��o                                   |
| :---------- | :--------- | :------------------------------------------ |
| `filePath`      | `string` | **Obrigat�rio**. Caminho onde o arquivo se encontra e o nome da pasta |

#### Upload do arquivo

```http
    curl --location '/api/v1/files/upload' \
    --header 'accept: */*' \
    --form 'fromFile=@"arquivo.pdf"' \
    --form 'path="/nomeDaPasta"'
```

| Par�metro   | Tipo       | Descri��o                                   |
| :---------- | :--------- | :------------------------------------------ |
| `fromFile`      | `file` | **Obrigat�rio**. Arquivo de upload. |
| `path`      | `string` | **Obrigat�rio**. Nome do caminho que ser� salvo o arquivo. |