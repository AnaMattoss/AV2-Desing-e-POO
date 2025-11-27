# Documentação da API E-commerce de Perfumes

## 📋 Visão Geral
Esta é uma API REST para um e-commerce de perfumes desenvolvida em C# com ASP.NET Core, seguindo os princípios de Clean Architecture e Programação Orientada a Objetos.

## 🏗️ Arquitetura do Projeto

### Estrutura de Pastas
```
AV2-Desing-e-POO/
├── Domain/                 # Camada de domínio (regras de negócio)
│   ├── Entities/          # Entidades do negócio
│   ├── Interfaces/        # Contratos dos serviços
│   └── Exceptions/        # Exceções customizadas
├── Application/           # Camada de aplicação (serviços)
│   └── Services/         # Implementação dos serviços
├── PerfumeStore.Api/     # Camada de apresentação (API)
│   ├── Controllers/      # Controladores da API
│   └── DTOs/            # Objetos de transferência de dados
└── Program.cs           # Configuração da aplicação
```

## 🎯 Conceitos de POO Aplicados

### 1. **Encapsulamento**
- **Onde:** Todas as entidades (Produto, Cliente, Carrinho, etc.)
- **Como:** Propriedades com `private set` e construtores controlados
- **Exemplo:**
```csharp
public class Produto
{
    public int Id { get; private set; }        // Só pode ser alterado internamente
    public string Nome { get; private set; }   // Protegido contra alterações externas
    public decimal Preco { get; private set; }
}
```

### 2. **Herança e Polimorfismo**
- **Onde:** Classe abstrata `Pagamento` e suas implementações
- **Como:** Classes filhas implementam comportamentos específicos
- **Exemplo:**
```csharp
public abstract class Pagamento
{
    public abstract bool Processar(); // Método abstrato
}

public class PagamentoPix : Pagamento
{
    public override bool Processar() => true; // Implementação específica
}
```

### 3. **Abstração**
- **Onde:** Interfaces dos serviços (`IProdutoService`, `ICarrinhoService`, etc.)
- **Como:** Contratos que definem comportamentos sem implementação
- **Exemplo:**
```csharp
public interface IProdutoService
{
    Produto Criar(string nome, decimal preco, int estoque);
    List<Produto> Listar();
}
```

## 📦 Entidades do Domínio

### **Produto**
- **Responsabilidade:** Representa um perfume no sistema
- **Atributos:** Id, Nome, Preço, Estoque
- **Métodos:** `BaixarEstoque()` - controla a redução do estoque
- **Regras:** Não permite estoque negativo ou quantidade inválida

### **Cliente**
- **Responsabilidade:** Representa um cliente do sistema
- **Atributos:** Id, Nome, Email
- **Características:** Entidade simples com dados básicos

### **Carrinho**
- **Responsabilidade:** Gerencia itens antes da compra
- **Atributos:** Lista de `ItemCarrinho`
- **Métodos:** 
  - `AdicionarItem()` - adiciona produto ao carrinho
  - `Total()` - calcula valor total dos itens

### **ItemCarrinho**
- **Responsabilidade:** Representa um item dentro do carrinho
- **Atributos:** Produto, Quantidade
- **Métodos:** `Subtotal()` - calcula preço × quantidade

### **Pedido**
- **Responsabilidade:** Representa uma compra finalizada
- **Atributos:** Id, Cliente, Carrinho, Pagamento, TotalFinal
- **Lógica:** Calcula total e processa pagamento automaticamente

### **Pagamento (Abstrata)**
- **Responsabilidade:** Define contrato para processamento de pagamentos
- **Implementações:** `PagamentoPix`, `PagamentoCartao`
- **Método:** `Processar()` - executa o pagamento

## 🔧 Camada de Serviços

### **ProdutoService**
- **Função:** Gerencia operações com produtos
- **Métodos:**
  - `Criar()` - cria novo produto com ID automático
  - `Listar()` - retorna todos os produtos
  - `ObterPorId()` - busca produto específico
- **Armazenamento:** Lista em memória (simulação de banco)

### **CarrinhoService**
- **Função:** Gerencia o carrinho de compras
- **Métodos:**
  - `AdicionarItem()` - adiciona produto ao carrinho
  - `ObterCarrinho()` - retorna carrinho atual
- **Validações:** Verifica se produto existe antes de adicionar

### **PedidoService**
- **Função:** Processa finalização de pedidos
- **Métodos:**
  - `Finalizar()` - cria pedido com cliente e pagamento
- **Validações:** 
  - Cliente deve existir
  - Carrinho não pode estar vazio
  - Tipo de pagamento deve ser válido
- **Cliente Teste:** Cria automaticamente cliente "Lucas" com ID 1

## 🌐 Camada de API (Controllers)

### **ProdutoController**
- **Rota:** `/api/produtos`
- **Endpoints:**
  - `POST /` - criar produto
  - `GET /` - listar produtos
- **Tratamento:** Try-catch para capturar erros

### **CarrinhoController**
- **Rota:** `/api/carrinho`
- **Endpoints:**
  - `POST /adicionar` - adicionar item
  - `GET /` - ver carrinho
- **Tratamento:** Validação de erros de produto não encontrado

### **PedidoController**
- **Rota:** `/api/pedidos`
- **Endpoints:**
  - `POST /finalizar` - finalizar pedido
- **Tratamento:** Validação de cliente e carrinho

## 📋 DTOs (Data Transfer Objects)

### **ProdutoDTO**
```csharp
public class ProdutoDTO
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}
```

### **ItemCarrinhoDTO**
```csharp
public class ItemCarrinhoDTO
{
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
}
```

### **PedidoDTO**
```csharp
public class PedidoDTO
{
    public int ClienteId { get; set; }
    public string TipoPagamento { get; set; } // "pix" ou "cartao"
}
```

## ⚙️ Configuração (Program.cs)

### **Injeção de Dependência**
```csharp
builder.Services.AddSingleton<IProdutoService, ProdutoService>();
builder.Services.AddSingleton<ICarrinhoService, CarrinhoService>();
builder.Services.AddSingleton<IPedidoService, PedidoService>();
```

### **Swagger**
- Documentação automática da API
- Interface para testar endpoints

## 🚀 Como Usar a API

### 1. **Criar um Produto**
```http
POST /api/produtos
{
    "nome": "Perfume Importado",
    "preco": 150.00,
    "estoque": 10
}
```

### 2. **Listar Produtos**
```http
GET /api/produtos
```

### 3. **Adicionar ao Carrinho**
```http
POST /api/carrinho/adicionar
{
    "produtoId": 1,
    "quantidade": 2
}
```

### 4. **Ver Carrinho**
```http
GET /api/carrinho
```

### 5. **Finalizar Pedido**
```http
POST /api/pedidos/finalizar
{
    "clienteId": 1,
    "tipoPagamento": "pix"
}
```

## 🔍 Principais Correções Realizadas

### **Problemas Encontrados e Soluções:**

1. **❌ Falta de arquivo .csproj**
   - **✅ Solução:** Criado arquivo de projeto com configurações necessárias

2. **❌ Imports faltando no Program.cs**
   - **✅ Solução:** Adicionados using statements para namespaces necessários

3. **❌ Uso de reflexão para setar IDs**
   - **✅ Solução:** IDs passados via construtor das entidades

4. **❌ Propriedade Valor em Pagamento mal encapsulada**
   - **✅ Solução:** Criado método `DefinirValor()` para controlar acesso

5. **❌ Falta de tratamento de erros**
   - **✅ Solução:** Try-catch em todos os controllers

6. **❌ Busca de entidades sem validação**
   - **✅ Solução:** Verificação de null antes de usar objetos

7. **❌ Acentuação incorreta em mensagens**
   - **✅ Solução:** Corrigidas mensagens de erro

## 🎓 Conceitos de Design Aplicados

### **Clean Architecture**
- Separação clara entre camadas
- Dependências apontam para dentro (Domain não depende de nada)
- Facilita testes e manutenção

### **SOLID Principles**
- **S**ingle Responsibility: Cada classe tem uma responsabilidade
- **O**pen/Closed: Extensível via herança (Pagamento)
- **L**iskov Substitution: Subclasses podem substituir classes pai
- **I**nterface Segregation: Interfaces específicas e focadas
- **D**ependency Inversion: Dependência de abstrações, não implementações

### **Repository Pattern (Simulado)**
- Serviços atuam como repositórios
- Abstração do armazenamento de dados
- Facilita troca de implementação (banco de dados real)

## 🔧 Tecnologias Utilizadas

- **ASP.NET Core 8.0** - Framework web
- **Swagger/OpenAPI** - Documentação da API
- **C# 12** - Linguagem de programação
- **Injeção de Dependência** - Padrão de design integrado

## 📝 Próximos Passos (Melhorias Possíveis)

1. **Banco de Dados:** Integrar Entity Framework
2. **Autenticação:** JWT para segurança
3. **Validações:** FluentValidation para DTOs
4. **Logs:** Serilog para rastreamento
5. **Testes:** Unit tests com xUnit
6. **Cache:** Redis para performance
7. **API Versioning:** Controle de versões da API