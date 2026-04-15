Minhas receitas API

O objetivo é construir uma API para gerenciar um livro de receitas digital, aplicando o controle do pipeline de requisições e diferentes tipos de endpoints.

1. Estrutura base (Minimal API)
Inicie o projeto como uma Minimal API e configure o pipeline.

2. Middleware de logging de acessos

Adicione um middleware chamado
ControleAcessosMiddleware, registrando no console:

· O Timestamp (data/hora), o Método HTTP e o Endpoint chamado (incluindo Rota + Query String), no formato 
timestamp | metodo HTTP | endpoint chamado.

3. Tabela de endpoints

Implemente os endpoints abaixo:

Método	Rota						Objetivo
GET		/api/receitas				Listar todas as receitas
GET	/api/receitas/{id:int}		Buscar uma receita por ID numérico
POST		/api/receitas			Cadastrar uma nova receita
PUT		/api/receitas/{id:int}		Atualizar os ingredientes de uma receita
DELETE	/api/receitas/{id:int}		Remover uma receita do catálogo


4. Tratamento Global de Erros

Configure o middleware de exceção para garantir que falhas no processamento (como um ingrediente nulo) sejam tratadas. Lembre de imprimir no console o caminho exato onde o erro ocorreu.
Obs:
Não utilize biblioteca de logs (logger, etc). Imprima as coisas no console usando Console.WriteLine() ;.
