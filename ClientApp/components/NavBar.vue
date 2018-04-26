<template>
    
    <nav class="navbar navbar-expand-lg navbar-light bg-white">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarTogglerDemo03" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <router-link to="/" class="navbar-brand">Jannie Couture</router-link>
        <div class="collapse navbar-collapse" id="navbarTogglerDemo03">
            <div class="row">
                <form class="form-inline mr-auto my-2 my-lg-0 col-lg-8">
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
                        <router-link to="/messages" class="nav-link">
                            <i class="fas fa-user">
                            </i>
                        </router-link>
                    </li>
                </ul>
            </div>
         </div>
    </nav>
</template>
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
</style>