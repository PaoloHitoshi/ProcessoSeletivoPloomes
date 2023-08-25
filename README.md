# TuneUPAPI

## API de Gerenciamento de Usuários e Músicas da Plataforma TuneUP
A TuneUP, se trata de uma plataforma de músicas fictícia similar ao Spotify. Esta API foi desenvolvida com este cenário em mente, permitindo o cadastro, consulta, atualização e remoção de usuários e músicas da plataforma, assim como permitir com que estes usuários criem, alterem e consultem playlists com suas músicas favoritas.

## Funcionalidades
### 1. Usuário

#### a. Obter Usuários da Plataforma
  Retorna todos os usuários cadastrados na plataforma
  Entrada:
   - Sem entrada.
     
#### b. Obter Usuários por Id
  Retorna o usuário de acordo com o Id desejado
  Entrada:
   - Id do usuário desejado.

#### c. Cadastrar Usuário na Plataforma
  Permite cadastrar um novo usuário na plataforma
  Entrada:
   - Requisição:
```
{
  "id": 0,
  "name": "string",
  "email": "string",
  "password": "string",
  "gender": "string",
  "date_Of_Birth": "2023-08-25T00:18:35.308Z"
}
```

#### d. Atualizar Informações de um Usuário
  Permite atualizar as informações de um usuário na plataforma
  Entrada:
   - Id do usuário desejado.
   - Requisição:
```
{
  "id": 0,
  "name": "string",
  "email": "string",
  "password": "string",
  "gender": "string",
  "date_Of_Birth": "2023-08-25T00:19:35.808Z"
}
```

#### e. Remover um Usuário
  Remove um usuário da plataforma
  Entrada:
   - Id do usuário desejado.

### 2. Registro de Músicas

#### a. Obter Músicas da Plataforma
  Retorna todas as músicas cadastradas na plataforma
  Entrada:
   - Sem entrada.
   
#### b. Obter Músicas por Id
  Retorna a música de acordo com o Id desejado
  Entrada:
   - Id da música desejada.
   
#### c. Obter Músicas de um Gênero
  Retorna uma lista de músicas de acordo com o gênero musical desejado
  Entrada:
   - Gênero musical desejado.
   
#### d. Obter Músicas de uma Banda
  Retorna uma lista de músicas de acordo com a banda desejada
  Entrada:
   - Nome da banda desejada.
   
#### e. Cadastrar uma Música na Plataforma
  Permite cadastrar uma nova música na plataforma
  Entrada:
   - Requisição:
```
{
  "id": 0,
  "name": "string",
  "genre": "string",
  "release_Date": "2023-08-25T00:11:43.111Z",
  "bandName": "string"
}
```

#### f. Atualizar Informações de uma Música
  Permite atualizar as informações de uma música na plataforma
  Entrada:
   - Id da música desejada.
   - Requisição:
```
{
  "id": 0,
  "name": "string",
  "genre": "string",
  "release_Date": "2023-08-25T00:14:22.789Z",
  "bandName": "string"
}
```

#### e. Remover uma Música
  Remove uma música da plataforma
  Entrada:
   - Id da música desejada.
   
### 3. Playlist De Músicas
#### a. Obter Playlist de Música por Id
Responsável por retornar uma playlist com base no Id passado
Entrada:
 - Id da playlist desejada.
#### b. Adicionar Música à uma Playlist
Responsável por adicionar uma música à uma playlist
Entrada:
 - Requisição:
```
{
  "id": 0,
  "name": "string",
  "userId": 0,
  "songId": 0,
  "user": {
    "id": 0,
    "name": "string",
    "email": "string",
    "password": "string",
    "gender": "string",
    "date_Of_Birth": "2023-08-25T00:08:10.828Z"
  },
  "song": {
    "id": 0,
    "name": "string",
    "genre": "string",
    "release_Date": "2023-08-25T00:08:10.828Z",
    "bandName": "string"
  }
}
```

#### c. Remover Música de uma Playlist
Responsável por remover uma música de uma playlist existente
Entrada:
 - Id da playlist desejada.
 - Id da música desejada.
   
## Tecnologias Utilizadas
### - Licensa: MIT
### - Linguagem de desenvolvimento: C#
### - Banco de dados: SQL Server

## Banco de Dados da API
O banco de dados da API está estruturada da seguinte forma:

### 1. Tabela de Usuários:
 - Id [Chave Primária]
 - Nome
 - E-mail
 - Senha
 - Gênero
 - Data de Nascimento

### 2. Tabela de Músicas:
 - Id [Chave Primária]
 - Nome
 - Gênero musical
 - Data de lançamento
 - Nome da banda
   
### 3. Tabela de Playlists:
 - Id [Chave Primária]
 - Nome
 - Id do usuário [Chave estrangeira para a tabela Usuários]
 - Id da música [Chave estrangeira para a tabela Músicas]
   
## Executar o Projeto

### Executar o código
 - Clonar o repositório: git clone https://github.com/PaoloHitoshi/ProcessoSeletivoPloomes.
 - Abrir o código no Visual Studio.
 - Executar o código através do atalho f5, esperando alguns segundos até que abra no seu navegador a API.

### Configurar o banco de dados
 - Certificar-se de ter instalado o SQL Server Management Studio (https://www.microsoft.com/pt-br/sql-server/sql-server-downloads).
 - Certificar-se de ter clonado o repositório seguindo os passos colocados acima.
 - No arquivo appsettings.json, alterar a variável DataBase dentro de ConnectionStrings para pegar as informações do seu banco local.
 - No Package Manager Console executar os seguintes comandos:
   - Add-Migration MigrationName -Context TuneUPDBContext
   - Update-Database -Context TuneUPDBContext
 - Por fim abrir SQL Server Management Studio, conectando-se no banco local e ver na aba de tabelas do banco para ver se funcionou.
