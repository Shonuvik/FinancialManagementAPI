# FinancialManagement
# Para execucão dessa API, siga os passos abaixo

# Gerar token de autenticação utilizando a api https://github.com/Shonuvik/AuthenticationAPI/tree/develop.

# Informar o token via header, conforme imagem de exemplo ![image](https://github.com/Shonuvik/FinancialManagementAPI/assets/34462179/b3d25541-f837-4506-8e87-51d34cda22c4)

# Rodar script abaixo em uma instancia de banco de dados SQL Server

 CREATE TABLE Expenses (
  id              INT           NOT NULL    IDENTITY    PRIMARY KEY,
  Name            VARCHAR(255)  NOT NULL,
  Type  	      VARCHAR(100),
  Value           NUMERIC(18, 2)
);


