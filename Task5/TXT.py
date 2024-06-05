class TextMemento:
    def __init__(self, content):
        self.content = content

class TextDocument:
    def __init__(self, content):
        self.content = content

    def get_content(self):
        return self.content

    def set_content(self, content):
        self.content = content

    def create_memento(self):
        return TextMemento(self.content)

    def restore_from_memento(self, memento):
        self.content = memento.content

class TextEditor:
    def __init__(self, document):
        self.document = document
        self.history = []

    def save(self):

        memento = self.document.create_memento()
        self.history.append(memento)

    def undo(self):
        if self.history:

            memento = self.history.pop()
            self.document.restore_from_memento(memento)

# Приклад використання
document = TextDocument("Initial text")
editor = TextEditor(document)


editor.save()
document.set_content("Modified text")
editor.save()
document.set_content("Even more modifications")
editor.save()


print("Current document content:", document.get_content())


editor.undo()
print("After undo:", document.get_content())


editor.undo()
print("After undo again:", document.get_content())
