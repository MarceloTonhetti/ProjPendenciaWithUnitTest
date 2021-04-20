# BarganhaNET
Projeto final do treimando

## Objetivo do projeto
 - Desenvolver um aplicativo baseado em cadastro de produtos para venda e compra pela internet

### Resumo
É um sistema de leilão onde os usuários cadastrados tem interesses em categorias de produtos ofertados por outros usuários. Podendo entrar para o leilão do produto da categoria de seu interesse e realizar lances.
O ganhador do leilão (quem deu o último lance) entra em um chat com o dono do produto ofertado, combinam entre si como será o pagamento e a entrega e avaliam um ao outro com pontos da plataforma.
The owner of sale can end the auction when he was enought offer.

### Como rodar o projeto
- Você precisará alterar a `connection string` no arquivo `appsettings.config`
 > `"BarganhaNetDBContextConnection": "Server=serverIp;DataBase=dbName;User ID=dbUsername;Password=dbPassword;"`
 > ou
 > `"Data Source=dbDataSource;Initial Catalog=dbName;Integrated Security=True;"`
- Em sequência você precisa atualizar o seu banco de dados. Para isso abra o  `Package Manager Console` e utilize este comando
-> `  Update-Database `

Pronto, é só cadastrar uns produtos do sistemas e dar uns lances 🤓.
