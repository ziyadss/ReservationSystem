<script>
	import Header from './Header.svelte';
	import Footer from './Footer.svelte';
	import '../styles.css';
</script>

<Header />
<body style="padding-bottom: 70px;">
	<main class="main">
		<slot />
	</main>
</body>
<Footer />
