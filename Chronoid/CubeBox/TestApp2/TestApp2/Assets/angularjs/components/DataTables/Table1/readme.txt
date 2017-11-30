READ ME
how to use my directive

header: '=',-> header  is for the th of the table
	-> [{ label:'Name'}, { label:'Email'}]
items: '=', -> is the items that will be displayed on the table data
the first element will not be displayed since this will serve as an id whenever you edit/modify that certain row
	-> [{ 0: 'asdsad-asdasd-asdasd', 1: 'ljbdelacruz', 2: 'ljbdelacruz123@gmail.com' }]
options:'',->is the option that will popup when you click the option of each row of the table
	->[{ icon: 'mdi-editor-insert-invitation', option: '2' }]
outputSelectedRow: '=',-> you can assign a value in here in order to get the item selected by your option
actionSelected:'=',->assign data here in order to get which option was performed in that item

