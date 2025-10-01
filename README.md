# 🧾 GetDataActiveDirectory

GetDataActiveDirectory é um utilitário de linha de comando em **C#** para o **.NET Framework 4.6.1** que consulta dados de usuários no Active Directory utilizando as APIs de `System.DirectoryServices`.

Com ele é possível informar o usuário e o domínio para listar informações de perfil, incluindo cargo, departamento, endereço, status de bloqueio e datas relacionadas à senha.

---

## 🛠️ Tecnologias Utilizadas

<p align="center">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-original.svg" alt=".NET" width="30" height="30"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" alt="C#" width="30" height="30"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/visualstudio/visualstudio-plain.svg" alt="Visual Studio" width="30" height="30"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/windows8/windows8-original.svg" alt="Windows" width="30" height="30"/>
</p>

- **C#** – linguagem principal
- **.NET Framework 4.6.1** – plataforma alvo
- **Console Application** – interface de linha de comando
- **Visual Studio** – ambiente de desenvolvimento recomendado

---

## 📂 Estrutura do Projeto

- `GetDataActiveDirectory.sln` – solução do Visual Studio
- `GetDataActiveDirectory/GetDataActiveDirectory.csproj` – projeto console principal
- `GetDataActiveDirectory/Program.cs` – ponto de entrada com a lógica de consulta
- `GetDataActiveDirectory/App.config` – configurações padrão do aplicativo

---

## ✅ Pré-requisitos

- Máquina Windows unida ao domínio corporativo
- **.NET Framework 4.6.1+** instalado
- Credenciais com permissão para ler dados de usuários no Active Directory
- **Visual Studio 2017** (ou versão mais recente compatível) para compilar/depurar

---

## ⚙️ Configuração

1. Clone ou baixe este repositório.
2. Abra `GetDataActiveDirectory.sln` no **Visual Studio**.
3. Restaure as referências necessárias (automático via NuGet/MSBuild do .NET Framework).
4. Ajuste, se necessário, as credenciais de execução ou o contexto do domínio no arquivo `Program.cs`.

---

## 🛠️ Compilação

1. No Visual Studio, selecione a configuração (`Debug` ou `Release`).
2. Compile o projeto (`Build > Build Solution`).
3. O executável será gerado em `GetDataActiveDirectory/bin/<Configuration>/`.

---

## ▶️ Execução

1. Abra um **Prompt de Comando** com permissões adequadas ao domínio.
2. Execute o aplicativo passando o **nome de usuário** (SAMAccountName) e o **nome do domínio**:
   ```bash
   GetDataActiveDirectory.exe <usuario> <dominio>
   ```
3. As informações coletadas serão exibidas no console e a aplicação aguardará `Enter` para finalizar.

---

## 🔎 Funcionamento

- Utiliza `PrincipalContext` e `UserPrincipal.FindByIdentity` para localizar o usuário no domínio informado.
- Converte o `UserPrincipal` em `DirectoryEntry` para acessar atributos adicionais como cargo, divisão e endereço.
- Calcula indicadores de bloqueio, status e expiração de senha diretamente das propriedades do Active Directory.
- Formata as datas importantes (último logon, troca e expiração de senha) no padrão `dd/MM/yyyy hh:mm:ss`.

---

## 📌 Observações

- Certifique-se de executar em um ambiente com conectividade ao controlador de domínio.
- Alguns campos podem retornar valores vazios caso não estejam preenchidos no Active Directory.
- Ajuste as mensagens para o idioma ou padrão desejado modificando as strings em `Program.cs`.

---

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
