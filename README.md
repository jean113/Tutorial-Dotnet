# Tutorial<br> ##

1. Rodar o comando `dotnet bew web -o nome da pasta`.<br>
2. Criar a classe que será a tabela (Pasta Model).<br>
3. Criar o appDbContext (pasta Data).<br>
4. Criar o mapping da tabela dentro do configure (pasta Data).<br>
5. Criar o handle e sua  interface.<br>
6. Criar um Response Genérico e um Request que será usado para cada interface.<br>
7. Configure o Program.cs para enxergar o appDbContext e os handlers. Certifique-se de que o appsettings está apontando para o seu Banco.<br>
8. Instalar o package Entity Framework do Banco que usa (Sql server, Mysql, sqlite e etc) e o EntityFrameworkCore.Design.<br>
9. Gerar as migrations e atualizar o database.<br>
10. Criar as controllers.<br>
11. Configurar o swagger.<br>
