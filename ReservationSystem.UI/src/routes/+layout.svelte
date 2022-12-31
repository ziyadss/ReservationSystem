<script>
	import Header from './Header.svelte';
	import Footer from './Footer.svelte';
	import './styles.css';
</script>

<div class="app">
	<Header />
	<body>
		<main class="main">
			<slot />
		</main>
	</body>
	<Footer />
</div>
