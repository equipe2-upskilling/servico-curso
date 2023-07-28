# # # # Projeto de Criação de Cursos
Este projeto é uma aplicação web que permite a criação, gerenciamento e visualização de cursos. Os cursos podem ser associados a professores e aulas. A aplicação é protegida por autenticação, garantindo que apenas usuários autorizados tenham acesso às funcionalidades.

# Funcionalidades
Listagem de Cursos

A página inicial da aplicação apresenta uma lista de todos os cursos cadastrados. Para cada curso, são exibidas informações como nome, descrição, duração, imagem de capa, professor associado, preço e status de matrícula.
Caso não haja cursos cadastrados, a mensagem "Não existem cursos cadastrados" é exibida.
Detalhes do Curso

Ao clicar em um curso na lista de cursos, o usuário é redirecionado para a página de detalhes do curso, onde são exibidas informações detalhadas sobre o curso selecionado, incluindo o nome, descrição, duração, preço, imagem de capa, professor associado e status de matrícula.
# Criação de Curso

Os usuários autorizados têm a capacidade de criar novos cursos. Ao acessar a página de criação de curso, o usuário pode preencher um formulário com os detalhes do curso, como nome, descrição, duração, professor associado, imagem de capa e preço.
Após o preenchimento correto dos campos e o envio do formulário, o novo curso é criado e adicionado à lista de cursos existente.
# Edição de Curso

Os usuários autorizados também podem editar os detalhes de um curso existente. Ao acessar a página de edição de curso, o usuário visualiza um formulário pré-preenchido com os detalhes atuais do curso.
É possível fazer alterações nos campos desejados e, em seguida, salvar as modificações. Após a conclusão bem-sucedida da edição, os detalhes do curso são atualizados.
# Exclusão de Curso

O projeto também permite que os usuários autorizados excluam cursos existentes. Ao selecionar a opção de exclusão, o curso selecionado é removido da lista de cursos.

# Tecnologias Utilizadas
Linguagem de programação: C#
Plataforma: ASP.NET MVC
Framework ORM: Dapper
Banco de Dados: PostgreSQL (Conectado via ElephantSQL)
