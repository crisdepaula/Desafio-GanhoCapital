#Desafio Ganho Capital
O objetivo deste exercício é implementar um programa de linha de comando (CLI) que calcula o imposto a ser pago sobre lucros ou prejuízos de operações no mercado financeiro de ações.
Por favor, leia as instruções abaixo e sinta-se à vontade para fazer perguntas, caso ache necessário.


## Definicao dos campos de entrada
operation Se a operação é uma operação de compra ( buy ) ou venda ( sell )
unit-cost Preço unitário da ação em uma moeda com duas casas decimais
quantity  Quantidade de ações negociadas



## Input json
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},{"operation":"sell", "unit-cost":50.00, "quantity": 10000},{"operation":"buy", "unit-cost":20.00, "quantity": 10000},{"operation":"sell", "unit-cost":50.00, "quantity": 10000}]

## Outpuet
 [{"tax":0.00},{"tax":80000.00},{"tax":0.00},{"tax":60000.00}]



## Regras
- nova-media-ponderada = ((quantidade-de-acoes-atual * media-ponderada atual) + (quantidade-de-acoes-compradas * valor-de-compra)) / (quantidade-de-acoes-atual +
quantidade-de-acoes-compradas)
nova-media-ponderada = ((quantidade-de-acoes-atual * media-ponderada atual) + (quantidade-de-acoes-compradas * valor-de-compra)) / (quantidade-de-acoes-atual +
quantidade-de-acoes-compradas)
Média Ponderada = (quantidade de ações atuais * cálculo médio ponderado atual) + (quantidade de ações compradas * preço de compra)) / (quantidade de ações atuais + quantidade de ações compradas)
- Calcular lucro
calcularProfit = (quantidade * custo unitário) - (quantidade * média ponderada)


bash
# importante estar atento à quebra de linha. 