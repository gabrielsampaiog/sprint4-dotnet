# TAQUI API

Esta é uma API desenvolvida em .NET que gerencia o cadastro de clientes utilizando o MongoDB e inclui integração com a API pública ViaCEP.

## Testes

### Teste de Conexão e Integração com a API Pública ViaCEP
- Este teste verifica a conectividade e a integração da API com o serviço ViaCEP, garantindo que os dados de endereço sejam obtidos corretamente.

### Teste de CRUD (Create, Read, Update e Delete)
- Este teste cobre as operações de criação, leitura, atualização e exclusão na controller principal (`ClientesController`), garantindo que as funcionalidades estejam operando conforme esperado.

## Práticas de Clean Code

O código do controlador `ClientesController` apresenta várias boas práticas de Clean Code, incluindo:

### 1. Nomenclatura Clara e Significativa
- Nomes de classes, métodos e variáveis são descritivos, facilitando a compreensão do que cada parte do código faz. Exemplos incluem `ClientesController`, `GetAll`, `Post`, `Put` e `Delete`.

### 2. Responsabilidade Única
- O controlador se concentra em gerenciar operações relacionadas a clientes, seguindo o princípio da responsabilidade única. Cada método tem uma única tarefa, como obter, criar, atualizar ou deletar um cliente.

### 3. Documentação com Comentários e XML
- O uso de comentários e anotações XML para descrever o propósito de cada método melhora a legibilidade e a manutenção do código, sendo útil para outros desenvolvedores que possam trabalhar com o código no futuro.

### 4. Tratamento de Erros e Respostas
- O controlador trata erros de forma adequada, retornando códigos de status HTTP apropriados e mensagens de erro descritivas, como `BadRequest`, `NotFound` e `InternalServerError`, ajudando na depuração e compreensão de falhas.

### 5. Uso de DTOs (Data Transfer Objects)
- A separação entre o modelo de domínio (`Cliente`) e os DTOs (`ClienteRequest` e `ClienteResponse`) ajuda a encapsular dados enviados e recebidos pela API, melhorando a manutenção e segurança dos dados sensíveis.

### 6. Métodos Assíncronos
- O uso de métodos assíncronos (`async/await`) permite uma melhor escalabilidade da aplicação, permitindo que outras solicitações sejam processadas enquanto a operação atual aguarda a conclusão de uma tarefa.

### 7. Injeção de Dependências
- O controlador utiliza injeção de dependência para receber o repositório de clientes, promovendo o desacoplamento e facilitando testes unitários.

### 8. Validação de Entrada
- A validação do ID nos métodos, utilizando `ObjectId.TryParse`, garante que a entrada esteja correta antes de prosseguir com a lógica, evitando possíveis erros de execução.

## Implementação de Machine Learning
- A aplicação inclui um algoritmo de machine learning que recomenda produtos com base nas visualizações do cliente, aprimorando a experiência do usuário e aumentando a relevância das sugestões de produtos.

## Como Executar
- Para executar a API, clone o repositório e siga as instruções no arquivo `INSTALL.md`.

## Licença
- Este projeto está licenciado sob a MIT License - veja o arquivo [LICENSE](LICENSE) para mais detalhes.
