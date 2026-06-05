# API PM (Problems Monitoring)

## Descrição do Projeto

O projeto é uma API REST desenvolvida utilizando **ASP.NET Core Web API**, **Entity Framework Core** e **Oracle Database**, criada para gerenciamento de um sistema de monitoramente de datacenters com base em sensores.

A API permite o cadastro e gerenciamento das informações relacionadas a:

- Funcionario
- Manutenção
- DataCenters
- Sensores
- Tipos de Alertas
- Alertas

Além do CRUD completo (Create, Read, Update e Delete), a aplicação também possui consultas específicas utilizando filtros para facilitar a busca de informações.

---

# Tecnologias Utilizadas

- C#
- ASP.NET Core Web API
- Entity Framework Core
- Oracle Database
- Swagger/OpenAPI
- Git/GitHub
- Visual Studio 2022

---

# Entidades do Sistema

## DataCenter
Armazena:
- Setor
- Status do datacenter

## Sensor
Armazena:
- Tipo do sensor
- Unidade de medida
- Atividade do sensor
- DataCenter associado

## TipoAlerta
Armazena:
- Tipo
- Nível do alerta
- Descrição

## Alerta
Armazena:
- Data do alerta
- Tipo de alerta associado
- Sensor associado

## Funcionario
Armazena:
- Nome
- Email
- Telefone
- Cargo

## Manutencao
Armazena:
- Data da manutenção
- Tipo de manutenção
- Status da manutenção
- Funcionário responsável
- Alerta associado

---

# Documentação das Rotas

## DataCenter

### GET

| Endpoint | Descrição |
|------------|------------|
| `/api/DataCenter` | Retorna todos os datacenters |
| `/api/DataCenter/{id}` | Retorna datacenter por ID |
| `/api/DataCenter/setor/{setor}` | Busca por setor |
| `/api/DataCenter/status/{status}` | Busca por status |

### POST

| Endpoint |
|-----------|
| `/api/DataCenter` |

Exemplo:

```json
{
  "setor": "Infraestrutura",
  "statusDatacenter": "Ativo"
}
```

### PUT

| Endpoint |
|-----------|
| `/api/DataCenter/{id}` |

### DELETE

| Endpoint |
|-----------|
| `/api/DataCenter/{id}` |

---

## Sensor

### GET

| Endpoint | Descrição |
|------------|------------|
| `/api/Sensor` | Retorna todos os sensores |
| `/api/Sensor/{id}` | Retorna sensor por ID |
| `/api/Sensor/datacenter/{dataCenterId}` | Busca sensores por datacenter |
| `/api/Sensor/tipo/{tipo}` | Busca por tipo de sensor |
| `/api/Sensor/atividade/{atividade}` | Busca por atividade do sensor |

### POST

| Endpoint |
|-----------|
| `/api/Sensor` |

Exemplo:

```json
{
  "tipoSensor": "Temperatura",
  "unidadeMedida": "°C",
  "atividadeSensor": "Ativo",
  "dataCenter_Id": 1
}
```

### PUT

| Endpoint |
|-----------|
| `/api/Sensor/{id}` |

### DELETE

| Endpoint |
|-----------|
| `/api/Sensor/{id}` |

---

## TipoAlerta

### GET

| Endpoint | Descrição |
|------------|------------|
| `/api/TipoAlerta` | Retorna todos os tipos de alerta |
| `/api/TipoAlerta/{id}` | Retorna tipo de alerta por ID |
| `/api/TipoAlerta/nivel/{nivel}` | Busca por nível do alerta |
| `/api/TipoAlerta/tipo/{tipo}` | Busca por tipo |

### POST

| Endpoint |
|-----------|
| `/api/TipoAlerta` |

Exemplo:

```json
{
  "tipo": "Superaquecimento",
  "nivel_alerta": "Crítico",
  "descricao": "Temperatura acima do limite permitido"
}
```

### PUT

| Endpoint |
|-----------|
| `/api/TipoAlerta/{id}` |

### DELETE

| Endpoint |
|-----------|
| `/api/TipoAlerta/{id}` |

---

## Alerta

### GET

| Endpoint | Descrição |
|------------|------------|
| `/api/Alerta` | Retorna todos os alertas |
| `/api/Alerta/{id}` | Retorna alerta por ID |
| `/api/Alerta/sensor/{sensorId}` | Busca alertas por sensor |
| `/api/Alerta/tipo/{tipoId}` | Busca alertas por tipo |

### POST

| Endpoint |
|-----------|
| `/api/Alerta` |

Exemplo:

```json
{
  "dataAlerta": "2026-06-05T10:30:00",
  "tipo_Id": 1,
  "sensor_Id": 1
}
```

### PUT

| Endpoint |
|-----------|
| `/api/Alerta/{id}` |

### DELETE

| Endpoint |
|-----------|
| `/api/Alerta/{id}` |

---

## Funcionario

### GET

| Endpoint | Descrição |
|------------|------------|
| `/api/Funcionario` | Retorna todos os funcionários |
| `/api/Funcionario/{id}` | Retorna funcionário por ID |
| `/api/Funcionario/cargo/{cargo}` | Busca por cargo |
| `/api/Funcionario/email/{email}` | Busca por email |

### POST

| Endpoint |
|-----------|
| `/api/Funcionario` |

Exemplo:

```json
{
  "nome": "Carlos Silva",
  "email": "carlos.silva@empresa.com",
  "telefone": "11999999999",
  "cargoFuncionario": "Técnico"
}
```

### PUT

| Endpoint |
|-----------|
| `/api/Funcionario/{id}` |

### DELETE

| Endpoint |
|-----------|
| `/api/Funcionario/{id}` |

---

## Manutencao

### GET

| Endpoint | Descrição |
|------------|------------|
| `/api/Manutencao` | Retorna todas as manutenções |
| `/api/Manutencao/{id}` | Retorna manutenção por ID |
| `/api/Manutencao/funcionario/{funcionarioId}` | Busca manutenções por funcionário |
| `/api/Manutencao/status/{status}` | Busca por status |
| `/api/Manutencao/tipo/{tipo}` | Busca por tipo de manutenção |

### POST

| Endpoint |
|-----------|
| `/api/Manutencao` |

Exemplo:

```json
{
  "dataManutencao": "2026-06-05T08:00:00",
  "tipoManutencao": "Preventiva",
  "statusManutencao": "Pendente",
  "funcionario_Id": 1,
  "alerta_Id": 1
}
```

### PUT

| Endpoint |
|-----------|
| `/api/Manutencao/{id}` |

### DELETE

| Endpoint |
|-----------|
| `/api/Manutencao/{id}` |

---

# Instalação e Execução

## Pré-requisitos

Instalar:

- .NET SDK 8
- Oracle Database
- Visual Studio 2022
- Git

---

## Restaurar dependências

```bash
dotnet restore
```

---

## Configurar conexão com banco

Abrir:

```json
appsettings.json
```

Editar:

```json
"ConnectionStrings": {
   "OracleConnection":"User Id=usuario;Password=senha;Data Source=localhost:1521/XEPDB1"
}
```

---

## Executar Migrations

Pelo Package Manager Console:

```powershell
Update-Database
```

ou pelo terminal:

```bash
dotnet ef database update
```

---

## Executar projeto

```bash
dotnet run
```

---

## Swagger

Após executar a aplicação:

```txt
/swagger
```

A interface Swagger permitirá visualizar e testar todos os endpoints disponíveis.

---

# Integrantes

- RM562979 - Caio Kenzo Tayra – 2TDSPI
- RM563000 - Enzo Vieira Bernardini - 2TDSPI
- RM561857 - Nicolas Mota Cândido - 2TDSPI