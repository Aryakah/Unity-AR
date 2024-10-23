k" href="../../../distribute/essentials/index.html">Essentials</a></li>
            <li class="dac-nav-item users">
              <a class="dac-nav-link" href="../../../distribute/users/index.html">Get Users</a></li>
            <li class="dac-nav-item engage">
              <a class="dac-nav-link" href="../../../distribute/engage/index.html">Engage &amp; Retain</a></li>
            <li class="dac-nav-item monetize">
              <a class="dac-nav-link" href="../../../distribute/monetize/index.html">Earn</a>
            </li>
            <li class="dac-nav-item analyze">
              <a class="dac-nav-link" href="../../../distribute/analyze/index.html">Analyze</a>
            </li>
            <li class="dac-nav-item stories">
              <a class="dac-nav-link" href="../../../distribute/stories/index.html">Stories</a>
            </li>
          </ul>
        </li>
        <li class="dac-nav-item preview">
          <a class="dac-nav-link" href="../../../preview/index.html">Preview</a>
        </li>
        </ul>
      </div>
    </div>
  </nav>
  <!-- end navigation-->
  

<!-- Nav Setup -->
<script>$('[data-dac-nav]').dacNav();</script>



  
    
  <div class="wrap clearfix" id="body-content">

  

  
  <div id="search-results" class="dac-search-results">
    <div id="dac-search-results-history" class="dac-search-results-history">
      <div class="wrap dac-search-results-history-wrap">
        <div class="cols">
          <div class="col-1of2 col-tablet-1of2 col-mobile-1of1">
            <h2>Most visited</h2>
            <div class="resource-flow-layout" data-history-query="history:most/visited" data-maxresults="3" data-cardsizes="18x2"></div>
          </div>

          <div class="col-1of2 col-tablet-1of2 col-mobile-1of1">
            <h2>Recently visited</h2>
            <div class="resource-flow-layout cols" data-history-query="history:recent" data-allow-duplicates="true" data-maxresults="3" data-cardsizes="18x2"></div>
          </div>
        </div>
      </div>
    </div>

    <div id="dac-search-results-content" class="dac-search-results-content">
      <div class="dac-search-results-metadata wrap">
        <div class="dac-search-results-for">
          <h2>Results for <span id="search-results-for"></span></h2>
        </div>

        <div id="dac-search-results-hero"></div>

        <div class="dac-search-results-hero cols">
          <div id="dac-search-results-reference" class="col-3of6 col-tablet-1of2 col-mobile-1of1">
            <div class="suggest-card reference no-display">
              <ul class="dac-search-results-reference">
              </ul>
            </div>
          </div>
          <div id="dac-custom-search-results"></div>
        </div>
      </div>

    </div>
  </div>





  
    
      
        <ul class="dac-header-crumbs">
          
        </ul>

        <!-- Breadcrumb Setup -->
        <p><script>$('.dac-nav-list').dacCurrentPage().dacCrumbs();</script></p>

        <h1 itemprop="name" >Support Library Setup</h1>
      
    
  


  

  
  <div id="jd-content">
    <div class="jd-descr" itemprop="articleBody">
    

    <div id="qv-wrapper">
  <div id="qv">

    <h2>In this document</h2>
    <ol>
      <li><a href="#download">Downloading the Support Library</a></li>
      <li><a href="#choosing">Choosing Support Libraries</a></li>
      <li><a href="#add-library">Adding Support Libraries</a></li>
      <li><a href="#using-apis">Using Support Library APIs</a>
        <ol>
          <li><a href="#manifest">Manifest Declaration Changes</a></li>
        </ol>
      </li>
    </ol>

    <h2>See also</h2>
    <ol>
      <li><a href="../../../tools/support-library/index.html#revisions">
        Support Library Revisions</a></li>
      <li><a href="../../../tools/support-library/features.html">
        Support Library Features</a></li>
    </ol>

  </div>
</div>

<p>How you setup the Android Support Libraries in your development project depends on what features
  you want to use and what range of Android platform versions you want to support with your
  application.</p>

<p>This document guides you through downloading the Support Library package and adding libraries
  to your development environment.</p>


<h2 id="download">Downloading the Support Libraries</h2>

<p>The Android Support Repository package is provided as a supplemental download
 to the Android SDK and is available through the Android
  <a href="../../../tools/help/sdk-manager.html">SDK Manager</a>. Follow the
  instructions below to obtain the Support Library files.
</p>

<p>To download the Support Library through the SDK Manager:</p>

<ol>
  <li>Start the Android <a href="../../../tools/help/sdk-manager.html">SDK Manager</a>.</li>
  <li>In the SDK Manager window, scroll to the end of the <em>Packages</em> list,
    find the <em>Extras</em> folder and, if necessary, expand to show its contents.</li>
  <li>Select the <strong>Android Support Repository</strong> item.</li>
  <li>Click the <strong>Install packages...</strong> button.</li>
</ol>

<img src="../../../images/tools/sdk-manager-support-libs.png" width="525" alt="" />
<p class="img-caption"><strong>Figu