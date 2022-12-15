
from pynput import keyboard
import requests as req
x = ""

def run():
    def on_press(key):
        global x
        if key == keyboard.Key.esc:
            return False  # stop listener
        try:
            k = key.char  # single-char keys
        except:
            k = key.name  # other keys
        print(k)
        x = x + k
        if k in ['enter']:  # keys of interest
            x = x.removesuffix('enter')
            # self.keys.append(k)  # store it in global-like variable
            print(x)
            url1 = 'https://localhost:7294/api/Purchases/item'
            url2 = 'https://localhost:7294/api/Products'
            r = req.get(url2 + "/" + x, verify=False)
            print(r.json())
            x = req.post(url1, json=r.json(), verify=False)
            print(x.text)
            return False  # stop listener; remove this if want more keys

    def activate():
        with keyboard.Listener(on_press=lambda event: on_press(event)) as listener:
            listener.join()

    activate()
    print(x)

run()
print("no more")
input()