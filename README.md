# README - ReceitaPerfeita API
# Introduction
A **ReceitaPerfeita API** é uma aplicação robusta e escalável desenvolvida em **.NET Core** para o gerenciamento completo de receitas culinárias. A API permite que os usuários se cadastrem, criem, editem e excluam receitas, oferecendo funcionalidades avançadas como a inclusão de título, ingredientes, instruções, tempo de preparo e nível de dificuldade. 

Além disso, a ReceitaPerfeita API se destaca pela integração com recursos modernos, como **autenticação via Google OAuth**, **integração com o Chat GPT** para geração automática de receitas baseadas em ingredientes fornecidos, e **hospedagem no Microsoft Azure**, garantindo desempenho e confiabilidade em ambientes de produção.

Este projeto não só visa entregar uma API funcional, mas também serve como um exemplo prático de boas práticas de desenvolvimento e padrões de arquitetura de software. Através da implementação de metodologias ágeis como **Scrum**, **DevOps**, **CI/CD**, e o design centrado no **Domain-Driven Design (DDD)**, buscamos otimizar tanto o processo de desenvolvimento quanto a qualidade do código, proporcionando uma experiência completa e eficiente para os desenvolvedores.

# Getting Started
Para rodar a ReceitaPerfeita API localmente, siga os passos abaixo:

#1. Installation Process
Clone este repositório:
git clone https://github.com/seu-usuario/receitaperfeita-api.git


# 2. Software Dependencies
Certifique-se de ter o seguinte instalado:

.NET SDK 6.0 ou superior
Docker (caso queira rodar a aplicação em um container)
Visual Studio ou Visual Studio Code (IDE recomendada)
SQL Server ou outro banco de dados configurado para persistência dos dados
3. Latest Releases
A última versão está disponível na branch main. Para garantir que você está usando a versão mais recente, faça um pull:


git pull origin main
4. API References
A API oferece endpoints RESTful para gerenciar receitas e usuários. Para uma descrição detalhada dos endpoints, consulte a documentação da API na pasta docs ou use o Swagger, que estará disponível após a execução do projeto.

Build and Test
1. Build the Code
Após a instalação das dependências, navegue até a pasta do projeto e execute o comando para compilar:


dotnet build
2. Run the Application
Execute a aplicação com o seguinte comando:


dotnet run
# 3. Running Unit Tests
Para rodar os testes unitários e garantir que todas as funcionalidades estão funcionando corretamente:


# dotnet test
Os testes incluem validações para garantir a consistência das regras de negócio e a integridade das receitas cadastradas.

# Contribute
Contribuições são bem-vindas! Se você deseja melhorar a ReceitaPerfeita API, siga os seguintes passos:

# Fork o repositório.
Crie uma branch para a sua modificação (git checkout -b minha-feature).
Faça as alterações desejadas e commit as mudanças.
Envie um pull request para a branch principal.
Certifique-se de que seu código esteja bem testado e siga as boas práticas de desenvolvimento (princípios SOLID, Clean Code, e DDD).

#License
Este projeto está licenciado sob a licença MIT - consulte o arquivo LICENSE para mais detalhes.
