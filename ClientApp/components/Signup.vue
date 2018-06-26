<template>
    <div class="container">
        <!-- Button to Open the Modal -->
        <!-- The Modal -->
        <div class="modal fade" id="signupModal">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Get Started </h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <!-- Modal body -->
                    <div class="modal-body">
                        <h4 v-if="hasMessage"  v-bind:class="messageStyle">  {{  message }}</h4>
                        <div class="form-group">
                            <label for="signupName">UserName:</label>
                            <input type="text"
                                   v-bind:class="nameStyle"
                                   id="signupName"
                                   autocomplete="name"
                                   v-model="name">
                            <div class="invalid-feedback">
                                Please provide a valid Username, at least 2 characters.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="signupEmail">Email:</label>
                            <input type="email"
                                   v-bind:class="emailStyle"
                                   id="signupEmail"
                                   autocomplete="email"
                                   v-model="email">
                            <div class="invalid-feedback">
                                Please provide a valid email.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="signupPassword">Password:</label>
                            <input type="password"
                                   v-bind:class="passwordStyle"
                                   id="signupPassword"
                                   autocomplete="password"
                                   v-model="password">
                            <div class="invalid-feedback">
                                Password should contain at least 6 characters.
                            </div>
                        </div>
                    </div>
                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button type="button"
                                class="btn btn-primary"
                                v-bind:disabled="inValidForm"
                                v-on:click="handleSignup">
                            Signup
                        </button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import { mapActions, mapState } from 'vuex';
import {
    isValidatePassword,
    isValidEmail,
    isValidUserName,
} from '../validators.js';

export default {
    name: 'Signup',
    computed: {
        ...mapState('auth', {
          message: state => state.message,
          hasMessage: state => state.messageForSignup,
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
</script>
<style>
    .close{
        color: white;
    }
    .modal-header {
        color: white;
        background: #153466
    }
    .modal-content {
        border: 0px;
    }
    .modal-footer .btn-primary {
         background: #153466
    }
</style>