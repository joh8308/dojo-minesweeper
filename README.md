# MineSweeper

> Have you ever played Minesweeper? It's a cute little game which comes within a certain Operating System whose name we can't really remember. Well, the goal of the game is to find all the mines within an MxN field. To help you, the game shows a number in a square which tells you how many mines there are adjacent to that square. For instance, take the following 4x4 field with 2 mines (which are represented by an * character):

```
  *...
  ....
  .*..
  ....
```

The same field including the hint numbers described above would look like this:

```
  *100
  2210
  1*10
  1110
```
You should write a program that takes input as follows:

  The input will consist of an arbitrary number of fields. The first line of each field contains two integers n and m (0 < n,m <= 100) which stands for the number of lines and columns of the field respectively. The next n lines contains exactly m characters and represent the field. Each safe square is represented by an "." character (without the quotes) and each mine square is represented by an "*" character (also without the quotes). The first field line where n = m = 0 represents the end of input and should not be processed.

Your program should produce output as follows:

For each field, you must print the following message in a line alone:

`Field #x:`

Where x stands for the number of the field (starting from 1). The next n lines should contain the field with the "." characters replaced by the number of adjacent mines to that square. There must be an empty line between field outputs.

## Clues

As you may have already noticed, each square may have at most 8 adjacent squares.

# Suggested Test Cases

This is the acceptance test input:
```
4 4
*...
....
.*..
....
3 5
**...
.....
.*...
0 0
```
and output:
```
Field #1:
*100
2210
1*10
1110
Field #2:
**100
33200
1*100
```

## References
This subject is copied here for covenience but the real original source is the codingdojo.org website : http://codingdojo.org/cgi-bin/index.pl?KataMinesweeper


## Restropective

### Structures de données
Structure de données rencontrées :

* Tableau de chaine à une dimension
* Tableaux de chaine à 2 dimensions
* Tableau d'entier à 2 dimensions (le 9 signifie une bombe)
* Tableau d'objet Case à 2 dimensions

Structure de données évoquées :
* Liste des bombes, calcul en direct du résultat de chaque case
* Liste de cases sous formes de liste chainées.
* Patron poids-mouche ? http://fr.wikipedia.org/wiki/Poids-mouche_(patron_de_conception)

### Ordre des tests possibles :

 1. Quel est la hauteur ?
 2. Quel est la largeur ?
 3. Est-ce que en x,y il y a une bombe ?
 4. Est-ce que en x,y il n'y a pas de bombe ?
 5. Est-ce que si je cherche une bombe en -1,-1 ca n'explose pas ?
 6. Est-ce que qu'il y a bien 1 bombe adjacente à x,y
 7. Résoudre une map simple du style `.*.\n...``
 8. Résoudre une map normale
 9. Résoudre deux maps à la suite



