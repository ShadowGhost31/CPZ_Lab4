class LightNode:
    pass

class LightTextNode(LightNode):
    def __init__(self, text):
        self.text = text

    def outerHTML(self):
        return self.text

class LightElementNode(LightNode):
    def __init__(self, tag_name, display_type, closing_type, css_classes=None):
        self.tag_name = tag_name
        self.display_type = display_type
        self.closing_type = closing_type
        self.css_classes = css_classes if css_classes is not None else []
        self.children = []
        self.event_listeners = {}

    def add_child(self, child):
        self.children.append(child)

    def add_event_listener(self, event_type, listener):
        if event_type in self.event_listeners:
            self.event_listeners[event_type].append(listener)
        else:
            self.event_listeners[event_type] = [listener]

    def remove_event_listener(self, event_type, listener):
        if event_type in self.event_listeners:
            if listener in self.event_listeners[event_type]:
                self.event_listeners[event_type].remove(listener)

    def trigger_event(self, event_type, *args):
        if event_type in self.event_listeners:
            for listener in self.event_listeners[event_type]:
                listener(*args)

    def outerHTML(self):
        attributes = ' '.join([f'{key}="{value}"' for key, value in self.__dict__.items() if key not in ['children', 'event_listeners']])
        children_html = ''.join([child.outerHTML() for child in self.children])
        if self.closing_type == 'single':
            return f'<{self.tag_name} {attributes}/>'
        else:
            return f'<{self.tag_name} {attributes}>{children_html}</{self.tag_name}>'

    def innerHTML(self):
        return ''.join([child.outerHTML() for child in self.children])
class LightImageNode(LightNode):
    def __init__(self, src):
        self.src = src

    def load_image_from_filesystem(self):
        # Логіка завантаження зображення з файлової системи
        print(f"Loading image '{self.src}' from filesystem.")

    def load_image_from_network(self):
        # Логіка завантаження зображення з мережі
        print(f"Loading image '{self.src}' from network.")

    def load_image(self):
        if self.src.startswith('http://') or self.src.startswith('https://'):
            self.load_image_from_network()
        else:
            self.load_image_from_filesystem()
def main():

    button = LightElementNode('button', 'inline', 'pair')
    button_text = LightTextNode('Click me!')
    button.add_child(button_text)


    def click_handler():
        print("Button clicked!")

    button.add_event_listener('click', click_handler)


    button.trigger_event('click')

    image1 = LightImageNode('local_image.jpg')
    image2 = LightImageNode('https://xxxx.com/xxxximage.jpg')


    image1.load_image()
    image2.load_image()

if __name__ == "__main__":
    main()
