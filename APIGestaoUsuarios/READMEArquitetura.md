Documento de Arquitetura da Solução
===================================

Visão Geral
-----------
A aplicação é uma API RESTful desenvolvida em ASP.NET Core, que implementa um CRUD básico de usuários. 
Ela protege senhas, registra auditoria de ações e padroniza respostas. 
A arquitetura segue separação em camadas para garantir organização e clareza.

Camadas da Arquitetura
----------------------
- Models: Entidades da aplicação (ex.: Usuario).
- DTOs: Objetos de transferência de dados (UsuarioCadastroDto, UsuarioAtualizacaoDto, UsuarioRespostaDto).
- Repositories: Responsáveis pela persistência em memória (UsuarioRepository).
- Services: Contêm a lógica de negócio (UsuarioService, AuditoriaService).
- Controllers: Exposição dos endpoints REST (UsuarioController).
- Configurations: Configurações externas e de infraestrutura (CorsConfig, JsonConfig).
- Filters/Middleware: Tratamento transversal, como padronização de resposta (ResponseWrapperFilter).

Fluxo de Requisição
-------------------
1. Cliente envia requisição HTTP (ex.: POST /api/v1/usuarios/cadastrar).
2. Controller recebe e valida os dados (DTO).
3. Service aplica regras de negócio (ex.: gerar hash da senha).
4. Repository persiste os dados em memória.
5. AuditoriaService registra a ação no log.
6. ResponseWrapperFilter padroniza a resposta antes de retornar ao cliente.

Decisões Técnicas
-----------------
- Proteção de senha: apenas o hash é armazenado, nunca a senha em texto puro.
- Async/await: todos os métodos são assíncronos, preparando para futura integração com banco real.
- CORS: configurado para permitir apenas o domínio do frontend.
- Respostas padronizadas: todas seguem o formato com dados_resposta, timestamp_resposta e tempo_da_resposta.
- Separação de responsabilidades: cada camada tem função clara, seguindo princípios SOLID.

Evidência de Proteção da Senha
------------------------------
- O campo Senha não é exposto em nenhuma resposta da API.
- Apenas o SenhaHash é armazenado internamente.
- Endpoint de verificação demonstra que o hash existe, mas não retorna a senha original.
