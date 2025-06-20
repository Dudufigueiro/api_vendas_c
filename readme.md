# API de Vendas

## Descrição
A API de Vendas é um sistema para gerenciar clientes, funcionários, categorias, produtos, vendas e itens de vendas. Ela fornece endpoints para realizar operações CRUD e outras funcionalidades relacionadas.

## Como executar

# Clonar o repositório
git clone git@github.com:Dudufigueiro/api_vendas_c.git

## Endpoints

### Categoria
- **GET /categorias**
  - Descrição: Lista todas as categorias.
  - Respostas:
    - 200: Lista de categorias retornada com sucesso.
      ```json
      [
        {
          "id": 1,
          "nome": "Eletrônicos",
          "codcategoria": 1
        },
        {
          "id": 2,
          "nome": "Roupas",
          "codcategoria": 2
        }
      ]
      ```

- **GET /categorias/{id}**
  - Descrição: Retorna os detalhes de uma categoria específica.
  - Parâmetros:
    - `id` (path): ID da categoria.
  - Respostas:
    - 200: Detalhes da categoria retornados com sucesso.
      ```json
      {
        "id": 1,
        "nome": "Eletrônicos",
        "codcategoria": 1
      }
      ```
    - 404: Categoria não encontrada.
      ```json
      {
        "erro": "Categoria não encontrada."
      }
      ```

