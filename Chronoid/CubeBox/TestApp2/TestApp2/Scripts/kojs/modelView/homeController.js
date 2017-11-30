var home = function () {
    var self = this;
    self.personsList = ko.observableArray([]);
    self.name = "John";
    self.LoadPerson = function() {
        $.getJSON("/Home/GetAllContactPerson", function (result) {
            result.forEach(function (r) {
                var temp = new Person();
                temp.id = r.Id;
                temp.name=r.name;
                self.personsList.push(temp);
            });
        });

        alert("Load Data");
    }
}
ko.applyBindings(home());