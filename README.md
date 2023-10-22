<p align="center">
  <img src="/RepoImages/logo.png?raw=true" alt="Logo">
</p>

TaskPlanner é um aplicativo simples em Blazor Server para gerenciamento de tarefas diárias.

## Instalação

O TaskPlanner foi configurado com um arquivo Docker Compose, eliminando a necessidade de configurações adicionais para executar a aplicação localmente. 
Siga os passos abaixo para começar:

1. **Instalação do Docker**: Certifique-se de que o Docker está instalado em sua máquina. Se você não tiver o Docker instalado, você pode encontrar instruções de instalação em [docker.com](https://www.docker.com/get-started).

2. **Clone o Repositório**: Clone este repositório para sua máquina local utilizando o seguinte comando:
   ```bash
   git clone https://github.com/Gilthayllor/TaskPlanner.git
   ```
3. **Acesse o Diretório Raiz**: Navegue para o diretório do projeto clonado:
   ```bash
   cd TaskPlanner
   ```
4. **Executar a aplicação**: Inicie o aplicativo utilizando o Docker Compose:
   ```bash
   docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
   ```
Após seguir esses passos, o TaskPlanner estará rodando localmente em seu ambiente em http://localhost:5000.

## Capturas de Tela

### Login
![Login](/RepoImages/task_planner_login.png?raw=true "Login")

### Registro
![Registro](/RepoImages/task_planner_register.png?raw=true "Registro")

### Tasks
![Tasks](/RepoImages/task_planner_tasks.png?raw=true "Tasks")

