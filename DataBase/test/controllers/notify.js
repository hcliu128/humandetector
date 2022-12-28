const Notify_SDK = require('line-notify-sdk');
require("dotenv").config();

const PushNotify = (message) => {
    try {
        // Notify
        const token = process.env.TOKEN;
        // notice a message
        new Notify_SDK().notify(token, message).then((body) => {
            console.log(body); //{ status: 200, message: 'ok' }
        })
    }
    catch (error) {
        console.log(error);
    }
}

module.exports = PushNotify;