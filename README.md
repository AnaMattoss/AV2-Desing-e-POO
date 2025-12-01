# AV2-Desing-e-POO
# 🛍️ E-commerce de Perfumes — API REST

API desenvolvida para simular o fluxo completo de um e-commerce de perfumes, aplicando na prática os principais conceitos de **Programação Orientada a Objetos (POO)**.

---

## 📌 Visão Geral do Projeto
- **Tecnologia:** ASP.NET Core + C#
- **Tipo:** API REST
- **Objetivo:** Implementar conceitos de POO com foco em organização, camadas e boas práticas.

---

## 🏗️ Arquitetura do Projeto

A solução é dividida em camadas para garantir organização e baixo acoplamento:

### **Domain**
- **Entities** — Entidades do domínio (Cliente, Produto, Carrinho, Pedido…)
- **Interfaces** — Contratos dos serviços
- **Exceptions** — Exceções customizadas do domínio

### **Application**
- **Services** — Contém toda a lógica de negócio (ClienteService, ProdutoService, CarrinhoService, PedidoService)

### **Api**
- **Controllers** — Endpoints de acesso à API
- **DTOs** — Objetos de entrada e saída de dados

---

## 🧱 Entidades Principais

### **Cliente**
Representa o usuário comprador da aplicação.

### **Produto**
Contém nome, preço, estoque e regras de validação.

### **ItemCarrinho**
Associa um produto à quantidade desejada.

### **Carrinho**
Gerencia itens, controla estoque e calcula totais automaticamente.

### **Pedido**
É criado a partir do cliente, carrinho e tipo de pagamento escolhido.

### **Pagamento (abstrato)**
Modela o pagamento e possui dois tipos concretos:
- Pagamento via Pix  
- Pagamento via Cartão  

Usa **herança** e **polimorfismo** para processar cada forma de pagamento.

---

## ⚙️ Serviços

### **ClienteService**
Gerencia dados de clientes e busca por ID.

### **ProdutoService**
Manipula dados e regras referentes a produtos.

### **CarrinhoService**
- Adiciona itens
- Valida estoque
- Exibe itens atuais
- Limpa carrinho após o pedido

### **PedidoService**
- Finaliza pedidos
- Seleciona tipo de pagamento
- Processa pagamento
- Calcula totais
- Limpa o carrinho automaticamente

---

## 🌐 Endpoints da API

### **Produtos**
- Criar produtos
- Listar produtos

### **Carrinho**
- Adicionar item ao carrinho
- Consultar carrinho atual

### **Pedidos**
- Finalizar pedido
- Selecionar forma de pagamento (pix/cartão)

---

## 🧠 Conceitos de POO Aplicados

- **Encapsulamento**  
  Controle rigoroso sobre como os dados são acessados e modificados.

- **Herança**  
  `Pagamento` → `PagamentoPix` / `PagamentoCartao`.

- **Polimorfismo**  
  Cada tipo de pagamento implementa sua própria lógica.

- **Abstração**  
  Interfaces definem contratos entre as camadas.

- **Exceções Customizadas**  
  Para regras específicas como estoque insuficiente e quantidade inválida.

---

## 🔄 Fluxo Principal da Aplicação

1. Cliente consulta e seleciona um produto  
2. Adiciona ao carrinho (estoque é atualizado automaticamente)  
3. Sistema calcula total em tempo real  
4. Cliente finaliza pedido informando método de pagamento  
5. Sistema processa pagamento e limpa o carrinho  

---

## 🚨 Tratamento de Erros

- Exceções específicas do domínio (ex: estoque insuficiente)
- Controllers retornam mensagens claras para o usuário da API

---

## 🧪 Testes no Swagger / Insomnia

Endpoints disponíveis para:
- Criar produtos
- Listar produtos
- Adicionar itens ao carrinho
- Visualizar carrinho
- Finalizar pedidos

Todos os fluxos podem ser testados facilmente pelas ferramentas.

---

## 🔗 Link do drive para acesso ao vídeo explicativo, UML e a documentação: 
  - ( https://drive.google.com/drive/folders/1Vlt7nYT9SYLYlObhrWc1sWC__28FLRvs?usp=sharing )

---

## 👤 Membros do Grupo
- 06009322 - Ana Luiza Maciel Mattos
- 06010493 - Lucas Frotté Lafin
- 06009234 - Heloiza Custódio
- 06010196 - Pedro Nogueira
- 06010096 - Ana Carolina Tomás
- 06010479 - Alexandre dos Santos 


