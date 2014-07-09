should = require('chai').should()

class MineSweeper
	height : 0
	width : 0

	constructor: (grid) ->
		return unless grid?
		lines = grid.split '\n'
		dimensions = lines[0].split ' '
		[@width, @height] = dimensions.map (el) -> parseInt(el)
		@minefield = lines[1..]

	isBomb: (x,y) ->
		@minefield[y]?[x] == '*'

	countBomb: (x,y) ->
		bombCount = 0
		for xx in [x-1..x+1]
			for yy in [y-1..y+1] when @isBomb xx,yy
				bombCount++ 	
		bombCount

	renderCell: (x,y) ->
		return '*' if @isBomb x,y
		"#{@countBomb(x,y)}"

	solve: ->
		result = ''
		for y in [0...@height]
			if y != 0

				result += '\n'
			for x in [0...@width]
				result += @renderCell x, y

		result

describe 'MineSweeper', ->

	it 'should instantiate my class', ->
		minesweeper = new MineSweeper
		should.exist minesweeper

	it 'should have 2 attributes width and height', ->
		minesweeper = new MineSweeper
		minesweeper.height.should.be.equal 0
		minesweeper.width.should.be.equal 0

	minesweeper = new MineSweeper """
		4 2
		.*..
		*...
		"""

	it 'should read height & width from input', ->
		minesweeper.height.should.be.equal 2
		minesweeper.width.should.be.equal 4
    
	it 'should detect correctly a bomb', ->
		minesweeper.isBomb(0,0).should.be.false

	it 'should not find a bomb when x or y is off grid', ->
		minesweeper.isBomb(0,42).should.be.false

	it 'should count correctly bomb around a cell', ->
		minesweeper.countBomb(0,0).should.be.equal 2

	it 'should render a cell', ->
		minesweeper.renderCell(0,0).should.be.equal '2'
		minesweeper.renderCell(1,0).should.be.equal '*'

	it 'should solve the minefield', ->
		minesweeper.solve().should.be.equal """
		2*10
		*210
		"""
