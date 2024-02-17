import { message } from "ant-design-vue"

export const AlertModal = (type, content) => {

    switch (type) {

        case "success": 
            message.success(content)
            break

        case "error":
            message.error(content)
            break

        case "warning":
            message.warning(content)
            break

        case "info":
            message.info(content)
            break

        default:
            break

    }
}

export default AlertModal