# Incremental Shop - Vertical Slice
No tema de RPG Medieval de Fantasia Clássica, o jogador tem uma loja que está indo mal e tem que pagar o aluguel para sobreviver.

## Funcionalidades básicas (versão protótipo)

<img width="1434" height="789" alt="image" src="https://github.com/user-attachments/assets/b3056df2-3b0a-48e3-a4dc-87831f82d813" />

### Interação básica
- Clientes chegam com N opções de coisas que querem vender
- E M opções de coisas que querem comprar
- O jogador tem um dinheiro base que pode escolher quais compra.
- Se comprar, depois esse item vai ser vendido acima do preço que pagou (no futuro dá pra fazer uns minions trabalharem pra polir os itens, deixá-los mágicos, coisas assim pra ficar mais caro)
- Se o jogador tiver o item que o cliente quer, dá pra vender.
- Aí fica sendo só algumas escolhas de compra e venda, só que a pessoa tem que ficar de olho na data pra pagar o aluguel. Se ela gastar dinheiro demais e não conseguir o suficiente pro aluguel, game over.
### "Dia-a-dia" da run
O jogador terá X dias até o dia do aluguel.
- Cada dia dura Y tempo

Em cada dia, aparecerão vários clientes, que sorteiam um conjunto de itens que tem para VENDER e outros para COMPRAR
- Os clientes formam uma fila única no balcão do jogador
- Imagino isso, pelo menos inicialmente, como um balãozinho em cima de suas cabeças.
- O jogador clica no item no balão do cliente para comprá-lo e no ícone em seu inventário para vender um item
- Há a opção de negar negociar com o cliente ("expulsá-lo da loja")

O dia acaba quando:
- Acabou o tempo do dia
- Não há mais clientes na loja

- Ao terminar o dia, o jogador tem a oportunidade de comprar upgrades pra sua loja
- Se chegar o dia do aluguel, será debitado do dinheiro total do jogador o custo do aluguel.

‼️Condição de derrota: Se o jogador NÃO TIVER DINHEIRO o suficiente, ele perde e o jogo recomeça do 0

## Links de coisas importantes
- [GitHub Repository](https://github.com/SirBernhart/incremental-shop)
- [Trello](https://trello.com/b/r6cD38nL)
- [Unity 6000.5.2f1](https://unity.com/pt/releases/editor/whats-new/6000.5.2f1)

### Pacotes externos
- [UniTask](https://github.com/Cysharp/UniTask.git)
