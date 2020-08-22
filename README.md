# API

Foi adicionado SwaggerUI na aplicação para facilitar a utilização sem Front-End [http://localhost:3000/swagger/index.html](http://localhost:3000/swagger/index.html)

## GET /accounts

Busca todas as contas com seu histórico de transações.
Parametros: Nenhum
Retorno:
[
{
"Id": 0,
"AccountNumber": 0,
"Balance": 0,
"OriginEntries": [
{
"Id": 0,
"OriginAccountId": 0,
"DestinyAccountId": 0,
"Value": 0
}
],
"DestinyEntries": [
{
"Id": 0,
"OriginAccountId": 0,
"DestinyAccountId": 0,
"Value": 0
}
]
}
]

## POST /accounts

Cria uma nova conta.
Parametros:

    {
        "AccountNumber":  0,
        "Balance":  0
    }

Retorno: OK

## POST /transactions

Cria uma nova transação da conta de origem para a destino
Parametros:

    {
        "OriginAccountNumber":  0,
        "DestinyAccountNumber":  0,
        "Value":  0
    }

Retorno: OK

# Respostas

## 1

DDD é um padrão de desenvolvimento focado em domínios e suas regras de negócio. É um padrão independente de linguagem, tem o mínimo de acoplamento possível, seguindo os padrões SOLID, tem camadas bem separadas, é favorável para código extensível e reutilizável.

## 2

Arquitetura em micros serviços é uma arquitetura onde cada responsabilidade/funcionalidade de um sistema fica dividia em serviços diferentes.
Cada serviço tem suas funções bem definidas e age de forma independente, a comunicação entre os serviços é feito via APIs, permitindo inclusive que os serviços sejam desenvolvidos em linguagens diferentes, permite também que caso seja necessário alterar algum desses serviços não tenha nenhum impacto sobre os outros, o mesmo é publicado individualmente.
Esse modelo tem um desafio que é o processamento mais custoso da aplicação já que a comunicação entre os serviços é feita por APIs.

## 3

Em uma comunicação Síncrona, o requisitante fica bloqueado aguardando uma resposta, é um cenário utilizado em uma transferência de arquivos grandes por exemplo.
Na comunicação assíncrona, o requisitante não fica bloqueado e não precisa ficar esperando a resposta, quando o requisitado termina o processo ele envia uma resposta e é executado a Callback do requisitante, é um cenário utilizado quando não precisa da resposta imediata, por exemplo uma gravação de log.
