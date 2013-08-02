function Task(data) {
    var self = this;

    self.id = data.Id;
    self.title = ko.observable(data.Name);
    self.status = ko.observable(data.State);
    self.isDone = ko.computed({
        read: function() {
            return self.status() == 'Done';
        },
        write: function (value) {
            if (value) {
                
                $.ajax({
                    url: '/api/values/' + self.id,
                    type: 'PUT',
                    success: function () {
                        self.status('Done');
                    }
                });
            }
        },
        owner: self
    });
}

function TaskListViewModel() {
    var self = this;
    self.tasks = ko.observableArray([]);
    self.newTaskText = ko.observable();

    self.refresh = function() {
        $.getJSON('/api/values', '', function (data) {
            self.tasks([]);
            $.each(data, function (item) {
                self.tasks.push(new Task(data[item]));
            });
        });
    };
    
    self.addTask = function () {
        $.post('/api/values', '=' + self.newTaskText(), function () {
            self.refresh();
            self.newTaskText('');
        });
    };

    self.refresh();
}

ko.applyBindings(new TaskListViewModel());