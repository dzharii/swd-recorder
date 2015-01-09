module WebElementExplorer {

    interface IEventListenerItem {
        type: string
        listener: any
    }

    class SwdPageRecorder {
        private listeners: IEventListenerItem[] = [
            {
                type: "contextmenu",
                listener: this.onBodyContextMenu.bind(this)
            },

            {
                type: "mouseover",
                listener: this.onBodyMouseover.bind(this)
            }

        ];

        init() {

            if (!document || !document.body) {
                this.logError("Critical. init(): document.body is not defined");
                return;
            }
            if (!document.body.addEventListener) {
                this.logError("Critical. init(): document.body.addEventListener is not defined");
                return;
            }

            this.listeners.forEach((item) => {
                document.body.addEventListener(item.type, item.listener, false)
            })
        }

        destructor() {
            this.listeners.forEach((item) => {
                document.body.removeEventListener(item.type, item.listener, false)
            })
        }

        onBodyContextMenu(event: MouseEvent) {

        }

        onBodyMouseover(event: MouseEvent) {

        }

        logError(error: string) {

        }
        
    }
}
