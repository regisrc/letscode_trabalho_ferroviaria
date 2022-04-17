## letscode_trabalho_ferroviaria
Trabalho realizado por Filipe Eduardo Regis

## Descrição
Desenvolver uma aplicação console que realize o gerenciamento de uma ferroviária e seus trens. Na qual deverá:
- cadastro e edição de funcionários 
- cadastro e edição de trens
- gerenciamento de chegada e saída dos trens

Deverá utilizar de lista ligada para gerenciar os trens;
Realizar o cadastro e edição dos dados em arquivo JSON;
Conter pelo menos 2 testes com a ferramenta que desejar;
Publicar no github com README explicando o fluxo de trabalho e processo de desenvolvimento, além de como realizar a execução.

## Execução

Para a execução do projeto é necessário estar com o .NET 6.0 instalado na maquina. Primeiramente rode a aplicação na sua maquina, após isso escolha o menu que você gostaria de utilizar, os seguintes menus estão disponíveis:

![image](https://user-images.githubusercontent.com/47003717/163730155-e991b787-2c47-45ac-b265-311c6195b2bb.png)

E dentro deles teremos submenus, e em todos eles podemos adicionar um novo, atualizar um existente ou visualizar todos.

![image](https://user-images.githubusercontent.com/47003717/163730172-f32378ed-2a20-41b3-948f-b6285b618b36.png)

![image](https://user-images.githubusercontent.com/47003717/163730174-c5a5113e-ba3f-4fbf-94d3-1bc9729fd421.png)

![image](https://user-images.githubusercontent.com/47003717/163730170-c7744d16-6381-40a2-8bf2-ae529901e7f7.png)

Para utilizar corretamente o submenu de inclusão ou atualização do gerenciamento de trem, na chegada e saída a string digitada deve estar da seguinte forma:

```csharp
2005-05-05 22:12 PM
```
No projeto também temos testes unitários, são 9 testes que foram feitos na classe 
```csharp
FuncionarioService.cs
```

![image](https://user-images.githubusercontent.com/47003717/163730272-fd7d84d1-0047-4785-88ee-72a665110172.png)

