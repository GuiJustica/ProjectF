### Prefabs
# Frangão - Personagem principal
- Descrição

  Personagem principal do jogo, o jogador é responsável por conduzi-lo ao longo do jogo.
- Quando são utilizados

  A personagem e suas funcionalidades estarão disponíveis durante todo o jogo (Mundo aberto e fases).
- Quais seus componentes
    - Sprites

      ![Frangao](https://github.com/mdarce765/DevJogos-ProjectF/blob/main/Imagens/Frangao/png/Mov/MovFre/FrangoFrente_2.png)
    - Colisores
 
      Polygon Collider 2D
      
      RigidBody 2D 
    - Fontes de audio

      - Andar
      
      - Atirar
      
      - Tomar dano
      
      - Pular
    - Scripts

      Possui funcionalidade de andar, falar (interação), pular (uma ou duas vezes), atirar e interação (Mundo Aberto).


# Mauaenses - Inimigos
- Descrição

  Inimigos gerais do jogo, pelo qual o jogador é responsável de derrotar durante as fases do jogo.
- Quando são utilizados

  Os inimigos e suas funcionalidades estarão disponíveis somente dentro das fases.
- Quais seus componentes
    - Sprites

      ![Inimigo](https://github.com/mdarce765/DevJogos-ProjectF/blob/main/Imagens/NPC/png/maua1.png)
    - Colisores
 
      Polygon Collider 2D 
      
      RigidBody 2D 
    - Fontes de audio

      - Andar
      
      - Atirar
      
      - Tomar dano

    - Scripts

      Possui funcionalidade de atrapalhar o jogador nas fases, onde pode andar e atirar.

# Penas - Munição do jogador
- Descrição

  Munição utilizada pelo jogador durante as fases. 
- Quando são utilizados

   As penas serão utilizadas quando o jogador apertar o botão de atirar.
   O jogador terá a opção de comprar uma melhoria de dano para a pena dentro do refeitório.
- Quais seus componentes
    - Sprites
      
      ![Pena](https://github.com/mdarce765/DevJogos-ProjectF/blob/main/Imagens/Frangao/png/pena5050.png)
    - Colisores
 
      Polygon Collider 2D
      
      RigidBody 2D 
    - Fontes de audio

      - Atirar

    - Scripts

      Atirar quando o jogador apertar o botão de atirar.

# O gaspar - Boss no final de cada fase do jogo 
- Descrição

  Vilão do nosso jogo, o frangão batalhará com ele até o final do jogo, na própria Mauá. 
- Quando são utilizados

   O Gaspar será utilizado no final de cada fase do jogo.

- Quais seus componentes
    - Sprites
      
      ![Gaspar](https://github.com/mdarce765/DevJogos-ProjectF/blob/main/Imagens/FantasmaMaua/png/mauaGhost6060.png)
    - Colisores
 
      Polygon Collider 2D
      
      RigidBody 2D 
    - Fontes de audio
      
      - Tomar dano

      - Mover
    
      - Atirar
    - Scripts

      Tem a funcionalidade de atirar, mover e falar (interação).


# Coruja do DACC - Ajudante do jogador 
- Descrição

  Aliada do jogador durante o mundo aberto, mostra as novas funcionalidades, e avisa os lugares que o jogador não consegue acessar. 
- Quando são utilizados

   Será utilizado somente no mundo aberto. 

- Quais seus componentes
    - Sprites
      
      ![Coruja](https://github.com/mdarce765/DevJogos-ProjectF/blob/main/Imagens/MapaFei/png/corujaDA.png)
    - Colisores
 
      Polygon Collider 2D
      
      RigidBody 2D 
    - Fontes de audio

    - Scripts

      Tem a funcionalidade de falar e dar dicar ao jogador.
