import { mapActions, mapState } from 'vuex';
import {
    isValidatePassword,
    isValidEmail,
    isValidUserName,
} from '../../validators.js';

export default {
  name: 'Signup',
  computed: {
    ...mapState('auth', {
      message: state => state.message,
      hasMessage: state => (state.messageRecipient == 'Signup'),
    }),
  },
  methods: {
    handleSignup(event) {
      event.preventDefault();
      const credentails = {
        Email: this.email,
        Password: this.password,
        UserName: this.name
      };
      this.$store.dispatch('auth/signup', credentails);
    },
    checkForm(field, operation) {
      let validInputs = this.validInputs;
      const fieldIndex = validInputs.indexOf(field);
      const fieldCSSClass = `${field}Style`;

      if (operation === 'add') {
        this[fieldCSSClass] = this[fieldCSSClass].toString().replace('is-invalid', '');
        if (fieldIndex === -1) {
          validInputs.push(field);
        }
      } else if (operation === 'remove') {
        if (fieldIndex !== -1) {
          this[fieldCSSClass] += ' is-invalid';
          validInputs = validInputs
            .filter((item, index) => index !== fieldIndex);
        }
      }

      this.validInputs = validInputs;

      // disable the submit button when every field are not valid
      if (validInputs.length === 3) {
        this.inValidForm = false;
      } else {
        this.inValidForm = true;
      }
    },
  },
  data() {
    return {
      email: '',
      password: '',
      rememberMe: true,
      inValidForm: true,
      validInputs: [],
      name: '',
      emailStyle: 'form-control',
      passwordStyle: 'form-control',
      nameStyle: 'form-control',
      messageStyle: 'text-center text-warning'
    };
  },
  watch: {
    email(val) {
      if (!isValidEmail(val)) {
        this.checkForm('email', 'remove');
      } else {
        this.checkForm('email', 'add');
      }
    },
    password(val) {
      if (!isValidatePassword(val)) {
        this.checkForm('password', 'remove');
      } else {
        this.checkForm('password', 'add');
      }
    },
    name(val) {
      if (!isValidUserName(val)) {
        this.checkForm('name', 'remove');
      } else {
        this.checkForm('name', 'add');
      }
    },
    jwtToken(val) {
      if (val) {
        document.getElementById('login').style.display = 'none';
      }
    },
    message(val) {
        if (val.toString().includes('success')) {
            this.messageStyle = this.messageStyle.toString().replace('text-warning', 'text-success');
        }
        else {
            this.messageStyle += ' text-warning';
        }
    },
  }
}
