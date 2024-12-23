# ![Projeto Taqui](https://i.ibb.co/0jg7twX/BANNER-TAQUI.png)

---

# SPRINT 04 - .NET

Disciplina: 
ADVANCED BUSINESS DEVELOPMENT WITH .NET

Professor: 
THIAGO KELLER

Entrega: 
Integração com uma API publica e machine learning.

Instruções de uso: Trocar Connection e Database no arquivo appsettings.json ou abrir o cmd e rodar os seguintes comandos: <br>
setx MONGODB_CONNECTION_STRING "string de conexao do mongodb" <br>
setx MONGODB_DATABASE "nome do seu banco"


```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Swagger": {
    "Title": "TAQUI API",
    "Description": "API para cadastrar clientes",
    "Email": "rm552342@fiap.com.br",
    "Name": "Grupo TAQUI"
  },
  "ClienteMongoDb": {
    "Connection": "",
    "Database": ""
  }
}
```
---

# Projeto TAQUI

Desenvolver um ambiente autossustentável que se concentre em analisar e fornecer insights com base no comportamento em tempo real dos consumidores é crucial. Priorizamos entender cada indivíduo em sua singularidade, em vez de agrupá-los em categorias genéricas. Conhecer a fundo a jornada atual e o histórico de uma pessoa, como John Doe, é mais valioso do que simplesmente rotulá-lo com características demográficas como gênero, orientação sexual, classe social, cor ou estado civil.

Diariamente, somos bombardeados por mais de 5 mil marcas diferentes***, através de uma variedade de canais de comunicação, alguns mais intrusivos que outros. Em média, uma pessoa percebe cerca de 153 anúncios entre os 362 aos quais é exposta diariamente. Destes, apenas cerca de 12 têm potencial para gerar engajamento e permanecer na memória do consumidor. ***

Há formas de comunicação mais intrusivas, onde dados pessoais são inseridos em sistemas, como números de telefone, e-mails ou qualquer cadastro que retenha informações identificadoras. SMS, MMS, notificações push, e-mails, chamadas telefônicas, WhatsApp, entre outros, são os principais canais utilizados pelas marcas para impactar os consumidores. É comum recebermos dezenas de ligações e mensagens de texto indesejadas por mês.

Diante desse cenário, como podemos verdadeiramente compreender um consumidor, sabendo quando, como, por que e o que recomendar a ele?

Nosso foco é entender o consumidor de forma individualizada, criando um sistema de recomendação eficaz. Através de uma análise de dados aprofundada, fornecemos insights valiosos para as empresas parceiras da Plusoft.

Aqui vão algumas estruturas fundamentais do nosso sistema:
Aprimorar algoritmos avançados para analisar grandes conjuntos de dados e identificar padrões de comportamento individual de maneira precisa e eficaz.

Garantir a precisão das recomendações, considerando não apenas os interesses expressos pelos usuários, mas também seus históricos de atividades e contexto atual, para oferecer sugestões relevantes e oportunas.

Implementar medidas robustas para proteger a privacidade e segurança dos dados dos usuários em todas as fases de coleta, processamento e análise, seguindo rigorosamente os padrões da Lei Geral da Proteção de Dados (LGPD).

Promover a conscientização das empresas sobre a importância estratégica de adotar estratégias de marketing personalizadas e centradas no usuário. Isso implica em abandonar o modelo tradicional de publicidade em massa e priorizar a criação de experiências relevantes e significativas para os consumidores, visando estabelecer conexões autênticas e duradouras com o público-alvo.

#### Fonte: 50 Estatísticas de Marketing Digital para 2024 (leadster.com.br)
---

## Pitch

[![Assista ao Pitch](https://i.ibb.co/DVRpqxq/taqui-imagem-tela-video-2.png)](https://www.youtube.com/playlist?list=PLnsC4Y30EcL7rDCMiPKU8FRtReYc_HDMP)

Assista ao vídeo do pitch para entender a proposta e a visão geral do projeto.

---
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

## Objetivo da Solução

Este projeto foi desenvolvido com os seguintes objetivos:

### Solução & Tecnologia
O sistema TAQUI oferece uma solução essencial para empresas que buscam se destacar e prosperar no mercado competitivo de hoje. Ao investir em nossa tecnologia de recomendação inteligente, você pode aprimorar suas estratégias de marketing de forma significativa.

### Alto impacto
Com o TAQUI, você maximiza a eficiência de suas campanhas, garantindo mensagens altamente relevantes para seu público-alvo. Isso aumenta as chances de conversão e fortalece o relacionamento com os clientes, gerando impacto com qualidade.

### Análise de dados
Além disso, ao aproveitar os dados fornecidos pelo sistema, você toma decisões orientadas por dados, baseadas em insights valiosos sobre tendências e comportamentos do consumidor. Isso resulta em uma melhor experiência do cliente e impulsiona o crescimento e a competitividade.

### Competitividade
Ao adotar o sistema TAQUI, você garante uma vantagem competitiva significativa, preparando-se para os desafios do mercado e alcançando sucesso a longo prazo.

---

## Entregas

Aqui você pode listar as entregas principais realizadas ao longo do projeto, descrevendo o progresso e resultados atingidos.

### Status de Entregas por Disciplina

| **Nome da Disciplina**                                       | **Data**       | **Status**        | **✔️** |
| ------------------------------------------------------------ | -------------- | ----------------- | ------ |
| Advanced Business Development with .NET                       | 04/11/2024     | Concluído         | ✅     |
| Compliance, Quality Assurance e Tests                        | 04/11/2024     | Em andamento      | 🔄     |
| DevOps Tools e Cloud Computing                               | 04/11/2024      | Não iniciado      | ❌     |
| Disruptive Architectures - IoT, IOB e Generated AI           | 04/11/2024      | Não iniciado      | ❌     |
| Java Advanced                                               | 04/11/2024      | Em andamento      | 🔄     |
| Mastering Relational and Non-Relational Database             | 04/11/2024      | Concluído         | ✅     |
| Mobile Application Development                               | 04/11/2024      | Em andamento      | 🔄     |

---

## Fotos do Projeto

Aqui estão algumas imagens do protótipo do smartphone desenvolvido:

<p align="center">
  <img src="https://i.ibb.co/31PR25G/215.png" alt="Imagem 1" width="30%" />
  <img src="https://i.ibb.co/zh7Q7DL/205.png" alt="Imagem 2" width="30%" />
  <img src="https://i.ibb.co/L9GZJL2/211.png" alt="Imagem 3" width="30%" />
</p>

---

## Equipe

Apresentação dos integrantes da equipe de desenvolvimento e suas responsabilidades no projeto:

- 2TDSPM Gabriel Sampaio RM 552342 - Banco de dados / C#
- 2TDSPM Gabriel Neves RM 552244 - React Native (Front End)
- 2TDSPM Livia Freitas RM 99892 - API Java
- 2TDSAV Rafael Mendonça RM 552422 - IA
- 2TDSPM Renato Romeu RM 551325 - DevOps, QA, UX, Business
  
---

## Links e Documentos Complementares

Aqui estão alguns links e documentos complementares para quem deseja explorar mais o projeto:

- [Link 1](https://www.figma.com/proto/GbHko9nmws9NPugbske524/TAQUI?node-id=75-2690&node-type=canvas&t=dseKhQZ0fE2nCp5Y-1&scaling=scale-down&content-scaling=fixed&page-id=62%3A2196&starting-point-node-id=75%3A2690) - Protótipo Figma
- [Link 2](https://drive.google.com/file/d/1174rHO_FRglp7t4-tU1j1UCGLTgB9j19/view?usp=sharing) - Documentação
- [Link 2](https://www.youtube.com/playlist?list=PLnsC4Y30EcL7rDCMiPKU8FRtReYc_HDMP) - Youtube

---

## Orientações de Uso

Aqui estão as orientações para uso correto do projeto:

1. Clone do repositório oficial:
   ```bash
   git clone https://github.com/gabrielsampaiog/sprint4-dotnet

Orientações gerais do produto final serão lançadas em breve.
