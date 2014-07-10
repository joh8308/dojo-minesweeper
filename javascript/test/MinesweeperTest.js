describe("Minesweeper", function () {
	beforeEach(function() {
		Minesweeper.clear();
	});
  
    it("should initialise minesweeper with number of cols and number of rows", function () {
		var minesweeperInst = Minesweeper.create(4,8);
		expect(minesweeperInst.nbRows).toBe(4);
		expect(minesweeperInst.nbCols).toBe(8);
    });
	
	it("should read input until number of rows is reach", function () {
		var minesweeperInst = Minesweeper.create(4,2);
		minesweeperInst.addRow("*.");
		minesweeperInst.addRow("..");
		minesweeperInst.addRow("..");
		expect(minesweeperInst.done).toBe(false);
		minesweeperInst.addRow(".*");
		expect(minesweeperInst.done).toBe(true);
	});
	
	it("should check that col number is correct when inserting row", function () {
		var minesweeperInst = Minesweeper.create(4,2);
		expect(function(){minesweeperInst.addRow(".*.")}).toThrow(new Error("le nombre de colonne est incorrect"));
		expect(function(){minesweeperInst.addRow(".")}).toThrow(new Error("le nombre de colonne est incorrect"));
	});
	
	it("should solve his own map", function () {
		var minesweeperInst = Minesweeper.create(2,2);
		minesweeperInst.addRow("*.");
		minesweeperInst.addRow("..");
		
		var expectedAnswer = "*1\n"+
							 "11\n";
		expect(minesweeperInst.solve()).toBe(expectedAnswer);
	});
	
	it("should set finished flat to true when last input is empty minesweeper", function () {
		var minesweeperInst = Minesweeper.create(2,2);
		minesweeperInst.addRow("*.");
		minesweeperInst.addRow("..");
		
		expect(Minesweeper.getResponse()).toBeUndefined();
		
		Minesweeper.create(0,0);
		
		expect(Minesweeper.getResponse()).toBeDefined();
	});
	
	
	it("should give answer creating a new empty minesweeper", function () {
		var minesweeperInst = Minesweeper.create(2,2);
		minesweeperInst.addRow("*.");
		minesweeperInst.addRow("..");
		
		Minesweeper.create(0,0);
		
		var response = Minesweeper.getResponse();
		var expectedAnswer = "Field #1:\n"+ 
							 "*1\n"+
							 "11\n";
		console.log("result : "+response);
		expect(response).toBe(expectedAnswer);
	});
	
	
	it("should solve complex minesweeper", function () {
		var minesweeperInst = Minesweeper.create(4,5);
		minesweeperInst.addRow("*..*.");
		minesweeperInst.addRow(".**..");
		minesweeperInst.addRow("...*.");
		minesweeperInst.addRow(".*...");
		Minesweeper.create(0,0);
		
		var response = Minesweeper.getResponse();
		var expectedAnswer = "Field #1:\n"+ 
							 "*33*1\n"+
							 "2**32\n"+
							 "234*1\n"+
							 "1*211\n";
		console.log("result : "+response);
		expect(response).toBe(expectedAnswer);
	});
	
	it("sould list all minesweeper solutions when input is empty minesweeper", function(){
		var minesweeperInst = Minesweeper.create(2,2);
		minesweeperInst.addRow("*.");
		minesweeperInst.addRow("..");
		
		var minesweeperInst = Minesweeper.create(4,5);
		minesweeperInst.addRow("*..*.");
		minesweeperInst.addRow(".**..");
		minesweeperInst.addRow("...*.");
		minesweeperInst.addRow(".*...");
		
		Minesweeper.create(0,0);
		
		var response = Minesweeper.getResponse();
		
		var expectedAnswer = "Field #1:\n"+ 
							 "*1\n"+
							 "11\n";
		expectedAnswer += "Field #2:\n"+ 
							 "*33*1\n"+
							 "2**32\n"+
							 "234*1\n"+
							 "1*211\n";
		console.log("result : "+response);
		expect(response).toBe(expectedAnswer);
	});
});