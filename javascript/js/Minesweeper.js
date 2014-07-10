(function(){
	
	function Inst(row, col){
		this.nbRows = row;
		this.nbCols = col;
		this.map = [];
		this.done = false;
	}
	Inst.prototype.addRow = function(input){
		if (!this.done){
			if (input.length != this.nbCols){
				throw new Error("le nombre de colonne est incorrect")
			}
			var array = [];
			for (var i=0; i<input.length; i++) {
				array.push(input.charAt(i));
			} 
			this.map.push(array);
			if (this.map.length == this.nbRows){
				this.done = true;
			}
		}
	}
	
	Inst.prototype.hasBomb = function(row, col){
		if (row > -1 && row < this.nbRows){
			if (col > -1 && col < this.nbCols){
				return this.map[row][col] === '*';
			}
		}
	}
	
	Inst.prototype.solve = function(){
		var	result = "";
		for(var i=0;i<this.map.length;i++){
			for(var j=0;j<this.map[i].length;j++){
				if (this.map[i][j] === '*') {
					result += '*';
				}else{
					var nbAdjBomb = 0;
					if (this.hasBomb(i-1,j-1)) nbAdjBomb++;
					if (this.hasBomb(i,j-1)) nbAdjBomb++;
					if (this.hasBomb(i-1,j)) nbAdjBomb++;
					if (this.hasBomb(i-1,j+1)) nbAdjBomb++;
					if (this.hasBomb(i+1,j-1)) nbAdjBomb++;
					if (this.hasBomb(i+1,j+1)) nbAdjBomb++;
					if (this.hasBomb(i,j+1)) nbAdjBomb++;
					if (this.hasBomb(i+1,j)) nbAdjBomb++;
					result += nbAdjBomb === 0 ? '.' : nbAdjBomb;
				}
			}
			result +='\n';
		}
		return result;
	}
	
	
	var isFinished = false;
	var listOfInst = [];
	
	function solve(){
		var result = "";
		for(var i=1; i<=listOfInst.length; i++){
			result += "Field #"+ i +":\n";
			result += listOfInst[i-1].solve();
		}
		return result;
	}
	
	window.Minesweeper = {
			clear:function(){
				listOfInst = [];
			},			
			create:function(row, col){
				if (row != 0 && col != 0){
					var inst = new Inst(row,col);
					listOfInst.push(inst);
					return inst;
				}else{
					isFinished = true;
				}
			},
			getResponse:function(){
				if (isFinished){
					return solve();
				}
				return undefined;
			}
	};
}()); 