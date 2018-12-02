import { mapActions, mapState } from 'vuex';
import {
  isValidatePassword,
  isValidEmail,
} from '../../validators.js';

export default {
  name: 'Login',
  computed: {
    ...mapState('auth', {
        message: state => state.message,
        jwt: state => state.jwt,
        hasMessage: state => (state.messageRecipient == 'Login'),
    }),
  },
  methods: {
    handleLogin(event) {
      event.preventDefault();
      const credentails = {
        Email: this.email,
        Password: this.password,
        // rememberMe: this.rememberMe,
      };
      this.$store.dispatch('auth/login', credentails);
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
      if (validInputs.length === 2) {
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
            emailStyle: 'form-control',
            passwordStyle: 'form-control'

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
        jwt(val) {
          if (val) {
            document.getElementById('loginModal').style.display = 'none';
            // hide bootstrap4 overlay
            document.getElementsByClassName('modal-backdrop')[0].style.display = 'none';

          }
        },
      },
}
