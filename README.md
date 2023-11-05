# CLAUDIO!STORE

API do meu E-commerce CLAUDIO!STORE

## VISÃO GERAL

  Criei a pasta Repository para lidar com a lógica envolvendo o Banco de Dados com o Entity Framework. 
  Aproveitei a Injeção de Dependência ( DI ) 
  Utilizei o banco de dados SQL Server
  E tive que lidar com o CORS para permitir que o Front pudesse utilizar minha API

## MÉTODOS HTTP UTILIZADOS

  -GET = Acabei usando o GET três vezes, um para buscar todos os produtos e com isso fazer os cards no front mostrando todos os produtos.
  
  -GET = Um GET para buscar por ID, para manipular individualmente.
  
  -GET = E um GET que faz uma busca, utilizei algumas técnicas para fazer a busca no banco de dados ignorando a sensibilidade das letras e acentuação.
  
  -POST = Utilizei o POST para efetuar uma compra, e de acordo com a quantidade selecionada pelo comprador ele fazer a subtração no banco de dados.



## FRONT DO PROJETO
  Você pode conferir o FRONT desse projeto clicando <a href="https://github.com/claudiokoori/front-claudiostore-v2"> AQUI </a>
