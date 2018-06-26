module.exports = {
  isValidEmail(email) {
    const regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (regex.test(email)) {
      return true;
    }
    return false;
  },
  isValidatePassword(password) {
    const regex = /^[a-zA-Z0-9!@#$%^&*]{6,26}$/;
    if (regex.test(password)) {
      return true;
    }
    return false;
  },
  isValidFullName(name) {
    const regex = /^(\s)?[a-zA-Z]{2,30}(\s[a-zA-Z]{2,30})?\s[a-zA-Z]{2,30}(\s)?$/;
    if (regex.test(name)) {
      return true;
    }
    return false;
  },
   isValidUserName(username) {
    const regex = /^[a-zA-Z0-9]{2,30}$/;
    if (regex.test(username)) {
      return true;
    }
    return false;
  },
}