<script lang="js">
	import logo from '$lib/images/logo.svg';
	import { page } from '$app/stores';
	import { browser } from '$app/environment';

	let loggedin = false;
	if (browser) {
		loggedin = localStorage.getItem('token') ? true : false;
	}


	function signOut() {
		if (browser) {
			window.localStorage.removeItem('token');
			window.localStorage.removeItem('role');
			alert('You have been logged out');
			window.location.replace('/');
		}
	}

    $: currentURL = $page.url.pathname;
</script>

<!--
<nav class="navbar navbar-expand-lg bg-body-tertiary">
  <div class="container-fluid">
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item">
            {#if currentURL.includes('match')}
                <a class="nav-link active" aria-current="page" href="/manager/match/list">Matches</a>
            {:else}
                <a class="nav-link" aria-current="page" href="/manager/match/list">Matches</a>
            {/if}
        </li>
        <li class="nav-item">
            {#if currentURL.includes('stadium')}
                <a class="nav-link active" href="/manager/stadium/list">Stadium</a>
            {:else}
                <a class="nav-link" href="/manager/stadium/list">Stadium</a>
            {/if}
        </li>
        <form class="d-flex" role="search">
            <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
            <button class="btn btn-outline-success" type="submit">Search</button>
        </form>
      </ul>
    </div>
  </div>
</nav> -->
<!-- Navbar -->
<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <!-- Container wrapper -->
  <div class="container">
    <!-- Toggle button -->
    <button
      class="navbar-toggler"
      type="button"
      data-mdb-toggle="collapse"
      data-mdb-target="#navbarButtonsExample"
      aria-controls="navbarButtonsExample"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <i class="fas fa-bars"></i>
    </button>

    <!-- Collapsible wrapper -->
    <div class="collapse navbar-collapse" id="navbarButtonsExample">
      <!-- Left links -->
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
            {#if currentURL.includes('match')}
                <a class="nav-link active" aria-current="page" href="/manager/match/list">Matches</a>
            {:else}
                <a class="nav-link" aria-current="page" href="/manager/match/list">Matches</a>
            {/if}
        </li>
        <li class="nav-item">
            {#if currentURL.includes('stadium')}
                <a class="nav-link active" href="/manager/stadium/create">Create Stadium</a>
            {:else}
                <a class="nav-link" href="/manager/stadium/create">Create Stadium</a>
            {/if}
        </li>
      </ul>
      <!-- Left links -->

      <div class="d-flex align-items-center">
        <button type="button" class="btn btn-dark-outline px-3 me-2" style="box-shadow: none;" on:click={() => signOut()}>
            Logout
        </button>
      </div>
    </div>
    <!-- Collapsible wrapper -->
  </div>
  <!-- Container wrapper -->
</nav>
<!-- Navbar -->

