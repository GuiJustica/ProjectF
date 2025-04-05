### Prefabs
# Frangão - Personagem principal
- Descrição

  Personagem principal do jogo, o jogador é responsável por condizir ao longo do jogo.
- Quando são utilizados

  A personagem e suas funcionalidades estarão disponíveis durante todo o jogo (Mundo aberto e fases).
- Quais seus componentes
    - Sprites

      ![Frangao](https://github.com/ChuckFelix765/DevJogos-ProjectF/blob/main/Sprites/imagem....-main/Frangao/.png/frangoparadofrente.png)
    - Colisores
 
      Polygon Collider 2D
      
      RigidBody 2D 
    - Fontes de audio

      Andar
      Atirar
      Tomar dano
      Pular
    - Scripts

      Possui funcionalidade de andar, falar (interação), pular (uma ou duas vezes), atirar e interação (Mundo Aberto).


# Mauaenses - Inimigos
- Descrição

  Inimigos gerais do jogo, pelo qual o jogador é responsável de derrotar durantes as fases do jogo.
- Quando são utilizados

  Os inimigos e suas funcionalidades estarão disponíveis somente dentro das fases.
- Quais seus componentes
    - Sprites

      ![Inimigo](https://github.com/ChuckFelix765/DevJogos-ProjectF/blob/main/Sprites/imagem....-main/NPC/.png/maua1.png)
    - Colisores
 
      Polygon Collider 2D 
      
      RigidBody 2D 
    - Fontes de audio

      Andar
      Atirar
      Tomar dano

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
      
      ![Pena](https://github.com/ChuckFelix765/DevJogos-ProjectF/blob/main/Sprites/imagem....-main/Frangao/.png/pena.png)
    - Colisores
 
      Polygon Collider 2D
      
      RigidBody 2D 
    - Fontes de audio

      Atirar
    - Scripts

      Atirar quando o jogador apertar o botão de atirar.

# O gaspar - Boss final 
- Descrição

  Inimigo final do jogo. 
- Quando são utilizados

   O Gaspar será utilizado somente na última fase do jogo.

- Quais seus componentes
    - Sprites
      
      ![Gaspar](https://github.com/ChuckFelix765/DevJogos-ProjectF/blob/main/Sprites/imagem....-main/FantasmaMaua/.png/gasparzinho.png)
    - Colisores
 
      Polygon Collider 2D
      
      RigidBody 2D 
    - Fontes de audio
      
      Tomar dano
      Mover
      Atirar
    - Scripts

      Tem a funcionalidade de atirar, mover e falar (interação).


# Coruja do DACC - Ajudante do jogador 
- Descrição

  Aliada do jogador durante o mundo aberto, mostra as novas funcionalidades, e avisa os lugares que o jogador não consegue acessar. 
- Quando são utilizados

   Será utilizado somente no mundo aberto. 

- Quais seus componentes
    - Sprites
      
      ![Coruja](https://github.com/ChuckFelix765/DevJogos-ProjectF/blob/main/Sprites/imagem....-main/image-removebg-preview%20(10).png)
    - Colisores
 
      Polygon Collider 2D
      
      RigidBody 2D 
    - Fontes de audio
      
      Falar
    - Scripts

      Tem a funcionalidade de falar e dar dicar ao jogador.
