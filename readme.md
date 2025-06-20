# API de Vendas

## Descri��o
A API de Vendas � um sistema para gerenciar clientes, funcion�rios, categorias, produtos, vendas e itens de vendas. Ela fornece endpoints para realizar opera��es CRUD e outras funcionalidades relacionadas.

## Como executar

# Clonar o reposit�rio
git clone git@github.com:Dudufigueiro/api_vendas_c.git

## Endpoints

### Categoria
- **GET /categorias**
  - Descri��o: Lista todas as categorias.
  - Respostas:
    - 200: Lista de categorias retornada com sucesso.
      ```json
      [
        {
          "id": 1,
          "nome": "Eletr�nicos",
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
  - Descri��o: Retorna os detalhes de uma categoria espec�fica.
  - Par�metros:
    - `id` (path): ID da categoria.
  - Respostas:
    - 200: Detalhes da categoria retornados com sucesso.
      ```json
      {
        "id": 1,
        "nome": "Eletr�nicos",
        "codcategoria": 1
      }
      ```
    - 404: Categoria n�o encontrada.
      ```json
      {
        "erro": "Categoria n�o encontrada."
      }
      ```

