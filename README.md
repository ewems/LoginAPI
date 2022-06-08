# LoginAPI

Para o correto funcionamento da aplicação seguir os seguintes passos:

1- Configurar as informações de conexão com o SQL Server (ServerConnection) através do arquivo appsettings, conforme abaixo:

"ServerConnection": "Persist Security Info=True; Initial Catalog=CADASTRO; Data Source=*{servidor}*; User ID=*{usuario}*; Password=*{senha}*"

Trocar os campos *{campo}* com as respectivas informações de conexão.

**Exemplo:**

Servidor: MeuServidor | Usuario: sa | Senha: 123456

**Resultado:**

"ServerConnection": "Persist Security Info=True; Initial Catalog=CADASTRO; Data Source=MeuServidor; User ID=sa; Password=123456"

2- Executar o script de criação e configuração do Banco de Dados contido no arquivo ScriptBanco.sql
