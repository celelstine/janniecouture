<template>
    
    <nav class="navbar navbar-expand-lg navbar-light bg-white" data-spy="affix" data-offset-top="197">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarTogglerDemo03" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <router-link to="/" class="navbar-brand">
            <img src="/images/logo.png" id="logo" />
        </router-link>
        <div class="collapse navbar-collapse" id="navbarTogglerDemo03">
            <div class="row">
                <form class="form-inline mr-auto my-2 my-lg-0 col-lg-6">
                    <input
                           class="form-control col-md-8 mr-sm-8"
                           id="navbar_searchbox" type="search"
                           placeholder="Search for dresses and costumes"
                           aria-label="Search"
                     >
                    <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                </form>
                <ul class="navbar-nav mt-2 mt-lg-0 ">
                    <li class="nav-item active">
                        <router-link to="/ageRange" class="nav-link">AgeRange</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link to="/messages" class="nav-link">Messages</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link to="/messages" class="nav-link">
                            <i class="fas fa-shopping-cart">
                                10
                            </i>
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <router-link
                                     to="/messages"
                                     class="nav-link username"
                                     v-if="userName"
                                     data-toggle="tooltip"
                                     data-placement="top"
                                     title="view to Profile">
                             <span> {{ userName }}</span>
                        </router-link>
                        <router-link to="/messages" class="nav-link" v-else>
                            <i class="fas fa-user">
                            </i>
                        </router-link>
                    </li>
                </ul>
            </div>
         </div>
    </nav>
</template>

<script>
import { mapState } from 'vuex';
export default {
    name: 'Navbar',
    computed: {
        ...mapState('auth', {
            userName: state => state.userName
        }),
    },
}
</script>
<style>
      #navbar_searchbox {
          background-color: #f8f9fa;
          color: #153466
      }
      .navbar-brand{
          color: #153466 !important;
          font-size: x-large;
          font-style: italic;
          font-weight: 900
      }
      .username {
          text-transform: capitalize;
          text-decoration: underline;
          color: #153466 !important;
          cursor: pointer;
          max-width: 85px;
          overflow: hidden;
      }
      .affix {
        top: 0;
        width: 100%;
        z-index: 9999 !important;
    }

    .affix + .container-fluid {
        padding-top: 70px;
    }
    #logo {
        width: 150px;
        height: 30px
    }
</style>
