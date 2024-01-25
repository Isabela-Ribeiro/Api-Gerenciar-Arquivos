# Gerenciar arquivos usando armazenamento de blobs da Azure

Uma poc que busca arquivos, exclui, verifica se existe e faz o upload de arquivos usando o armazenamento de blobs da azure.


## Documentação da API

#### Retorna o arquivo para download

```
  GET /api/v1/files?file-path=/nomeDaPasta/nomeDoArquivo
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `file-path` | `string` | **Obrigatório**. Caminho onde o arquivo se encontra e o nome da pasta |

#### Retorna se o arquivo existe

```
  GET /api/v1/files/exist?file-path=/nomeDaPasta/nomeDoArquivo
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `file-path`      | `string` | **Obrigatório**. Caminho onde o arquivo se encontra e o nome da pasta |

#### Deleta o arquivo se existe

```
  curl --location --request DELETE '/api/v1/files' \
  --header 'accept: */*' \
  --header 'Content-Type: application/json' \
  --data '{ "filePath": "/nomeDaPasta/nomeDoArquivo" }'
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `filePath`      | `string` | **Obrigatório**. Caminho onde o arquivo se encontra e o nome da pasta |

#### Upload do arquivo

```
    curl --location '/api/v1/files/upload' \
    --header 'accept: */*' \
    --form 'fromFile=@"arquivo.pdf"' \
    --form 'path="/nomeDaPasta"'
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `fromFile`      | `file` | **Obrigatório**. Arquivo de upload. |
| `path`      | `string` | **Obrigatório**. Nome do caminho que será salvo o arquivo. |