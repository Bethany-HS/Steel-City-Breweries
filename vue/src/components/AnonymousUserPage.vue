ANONYMOUS USER PAGE

<template>
  <div id="main">
      <h1 id="intro-txt">
        Find the right brew for you!
      </h1>
      <h2 id="search-our-list-txt">
        - Search our list of breweries in the Pittsburgh area
      </h2>
      <p>
        Steel City Brews is your one stop for that bubbly hop pop.
        <br>
        <br>
        Pittsburgh is best known for its rivers and bridges, but did you know that Steel Town is also home to some of the best breweries this side of the Monongahela?
        <br>
        That’s right. You can enjoy dozens of delicious brews and enjoy mind bending views all within the confines of the city.
        From Urban Tap to Southern Tier, you’re in the right place to chug or sip a beer. 
        Does your fading and foggy memory of last night taste like heaven? Then you can logon to Steel City Brews and rate that beer an 11!
        <br><br>
        (Note: Rating system is based off of the 5 star system.)
        <br><br> 
        Meet a pretty gal or guy while searching for that perfect microbrew? 
        <br>
        Add some breweries to your favorites list that they can enjoy too! 
        Don’t forget to leave a review.
      </p>
  </div>
</template>

<script>
export default {
    name: "anonymous-user-page",
}
</script>

<style>
#main {
    display: flex;
    align-items: flex-start;
    flex-direction: column;
}

#main > h1, h2, p {
    color: white;
    background-color: rgba(53, 53, 53, 0.8);
    padding: 1rem;
    border-radius: 10px;
}

#main > h1 {
  font-size: 3rem;
  margin-top: 10%;

}

#main > h2 {
  font-size: 1.2rem;
}

#main > p {
    font-size: 1.5rem;
    margin-top: 7%;
}
</style>