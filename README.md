Desafio Delta Fire

Esta API foi criada para gerenciar um sistema de vendas. Ela permite o cadastro de produtos e clientes, gerenciamento de vendas e estoque, e geração de relatórios de vendas.
Funcionalidades
1.	Cadastro de Produtos: Permite o registro de informações detalhadas sobre um produto, como nome, preço, descrição, fornecedor, data de validade, etc.
2.	Cadastro de Clientes: Permite o registro de informações sobre os clientes, como nome, endereço, telefone, etc.
3.	Gerenciamento de Vendas: Permite registrar uma venda associando um cliente a um ou mais produtos vendidos, com quantidade e preço. Também permite buscar todas as vendas realizadas por um cliente específico e gerar relatórios sobre vendas diárias, mensais.
4.	Gerenciamento de Estoque: Permite registrar a entrada de novos produtos no estoque e controlar a quantidade de itens em estoque após uma venda.

Instalação
Clone o repositório para a sua máquina local.
git clone https://github.com/digo2112/Desafio1

Navegue até a pasta do projeto e restaure os pacotes NuGet.
cd Desafio1
dotnet restore

Agora você pode executar o projeto.
dotnet run

Uso da API

Cliente
Os seguintes endpoints estão disponíveis para Cliente:
•	GET /api/Cliente: Retorna uma lista de todos os clientes.
•	GET /api/Cliente/{id}: Retorna o cliente com o ID especificado.
•	POST /api/Cliente: Cria um novo cliente. O corpo da solicitação deve incluir os detalhes do cliente no formato JSON.
•	PUT /api/Cliente/{id}: Atualiza o cliente com o ID especificado. O corpo da solicitação deve incluir os detalhes do cliente atualizados no formato JSON.
•	DELETE /api/Cliente/{id}: Exclui o cliente com o ID especificado.


Detalhes de Vendas
Os seguintes endpoints estão disponíveis para DetalhesVendas:
•	GET /api/DetalhesVendas: Retorna uma lista de todos os detalhes de vendas.
•	GET /api/DetalhesVendas/{id}: Retorna os detalhes de venda com o ID especificado.
•	POST /api/DetalhesVendas: Cria novos detalhes de venda. O corpo da solicitação deve incluir os detalhes da venda no formato JSON.
•	PUT /api/DetalhesVendas/{id}: Atualiza os detalhes de venda com o ID especificado. O corpo da solicitação deve incluir os detalhes da venda atualizados no formato JSON.
•	DELETE /api/DetalhesVendas/{id}: Exclui os detalhes de venda com o ID especificado.

Produtos
Os seguintes endpoints estão disponíveis para Produtos:
•	GET /api/Produtos: Retorna uma lista de todos os produtos.
•	GET /api/Produtos/{id}: Retorna o produto com o ID especificado.
•	GET /api/Produtos/por-categoria/{id}: Retorna os produtos da categoria com o ID especificado.
•	GET /api/Produtos/por-fornecedor/{id}: Retorna os produtos do fornecedor com o ID especificado.
•	GET /api/Produtos/por-validade/{data}: Retorna os produtos com a data(yyyy-MM-dd)(yyyy-MM-dd) de validade especificada.
•	GET /api/Produtos/por-cadastro/{inicio}/{fim}: Retorna os produtos cadastrados entre as datas((yyyy-MM-dd)) de início e fim especificadas.
•	POST /api/Produtos: Cria um novo produto. O corpo da solicitação deve incluir os detalhes do produto no formato JSON.
•	PUT /api/Produtos/{id}: Atualiza o produto com o ID especificado. O corpo da solicitação deve incluir os detalhes do produto atualizados no formato JSON.
•	DELETE /api/Produtos/{id}: Exclui o produto com o ID especificado

Vendas
Os seguintes endpoints estão disponíveis para Vendas:
•	GET /api/Vendas: Retorna uma lista de todas as vendas.
•	GET /api/Vendas/{id}: Retorna a venda com o ID especificado.
•	GET /api/Vendas/diarias/: Retorna as vendas diárias a partir da data(yyyy-MM-dd) especificada.
•	GET /api/Vendas/mensais/: Retorna as vendas mensais a partir da data(yyyy-MM-dd) especificada.
•	POST /api/Vendas: Cria uma nova venda. O corpo da solicitação deve incluir os detalhes da venda no formato JSON.
•	PUT /api/Vendas/{id}: Atualiza a venda com o ID especificado. O corpo da solicitação deve incluir os detalhes da venda atualizados no formato JSON.
•	DELETE /api/Vendas/{id}: Exclui a venda com o ID especificado.