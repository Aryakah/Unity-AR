   <a href="/about/android.html">About Android</a>
      <a href="/auto/index.html">Auto</a>
      <a href="/tv/index.html">TV</a>
      <a href="/wear/index.html">Wear</a>
      <a href="/legal.html">Legal</a>

      <span id="language" class="locales">
        <select name="language" onchange="changeLangPref(this.value, true)">
          <option value="en" selected="selected">English</option>
          <option value="es">Español</option>
          <option value="in">Bahasa Indonesia</option>
          <option value="ja">日本語</option>
          <option value="ko">한국어</option>
          <option value="pt-br">Português Brasileiro</option>
          <option value="ru">Русский</option>
          <option value="vi">tiếng Việt</option>
          <option value="zh-cn">中文（简体)</option>
          <option value="zh-tw">中文（繁體)</option>
        </select>
      </span>
    </p>
  </div>
</div>
<!-- end footer -->



  



<div data-modal="newsletter" data-newsletter data-swap class="dac-modal newsletter">
  <div class="dac-modal-container">
    <div class="dac-modal-window">
      <header class="dac-modal-header">
        <div class="dac-modal-header-actions">
          <button class="dac-modal-header-close" data-modal-toggle></button>
        </div>
        <div class="dac-swap" data-swap-container>
          <section class="dac-swap-section dac-active dac-down">
            <h2 class="norule dac-modal-header-title" data-t="newsletter.title"></h2>
            <p class="dac-modal-header-subtitle" data-t="newsletter.requiredHint"></p>
          </section>
          <section class="dac-swap-section dac-up">
            <h2 class="norule dac-modal-header-title" data-t="newsletter.successTitle">Hooray!</h2>
          </section>
        </div>
      </header>
      <div class="dac-swap" data-swap-container>
        <section class="dac-swap-section dac-active dac-left">
          <form action="https://docs.google.com/forms/d/1QgnkzbEJIDu9lMEea0mxqWrXUJu0oBCLD7ar23V0Yys/formResponse" class="dac-form" method="post" target="dac-newsletter-iframe">
            <input type="hidden" name="entry.935454734" data-newsletter-language>
            <section class="dac-modal-content">
              <fieldset class="dac-form-fieldset">
                <div class="cols">
                  <div class="col-1of2 newsletter-leftCol">
                    <div class="dac-form-input-group">
                      <label for="newsletter-full-name" class="dac-form-floatlabel" data-t="newsletter.name">Full name</label>
                      <input type="text" class="dac-form-input" name="entry.1357890476" id="newsletter-full-name" required>
                      <span class="dac-form-required">*</span>
                    </div>
                    <div class="dac-form-input-group">
                      <label for="newsletter-email" class="dac-form-floatlabel" data-t="newsletter.email">Email address</label>
                      <input type="email" class="dac-form-input" name="entry.472100832" id="newsletter-email" required>
                      <span class="dac-form-required">*</span>
                    </div>
                  </div>
                  <div class="col-1of2 newsletter-rightCol">
                    <div class="dac-form-input-group">
                      <label for="newsletter-company" class="dac-form-floatlabel" data-t="newsletter.company">Company / developer name</label>
                      <input type="text" class="dac-form-input" name="entry.1664780309" id="newsletter-company">
                    </div>
                    <div class="dac-form-input-group">
                      <label for="newsletter-play-store" class="dac-form-floatlabel" data-t="newsletter.appUrl">One of your Play Store app URLs</label>
                      <input type="url" class="dac-form-input" name="entry.47013838" id="newsletter-play-store" required>
                      <span class="dac-form-required">*</span>
                    </div>
                  </div>
                </div>
              </fieldset>
              <fieldset class="dac-form-fieldset">
                <div class="cols">
                  <div class="col-1of2 newsletter-leftCol">
                    <legend class="dac-form-legend"><span data-t="newsletter.business.label">Which best describes your business:</span><span class="dac-form-required">*</span>
                    </legend>
                    <div class="dac-form-radio-group">
                      <input type="radio" value="Apps" class="dac-form-radio" name="entry.1796324055" id="newsletter-business-type-app" required>
                      <label for="newsletter-business-type-app" class="dac-form-radio-button"></label>
                      <label for="newsletter-business-type-app" class="dac-form-label" data-t="newsletter.business.apps">Apps</label>
                    </div>
                    <div class="dac-form-radio-group">
                      <input type="radio" value="Games" class="dac-form-radio" name="entry.1796324055" id="newsletter-business-type-games" required>
                      <label for="newsletter-business-type-games" class="dac-form-radio-button"></label>
                      <label for="newsletter-business-type-games" class="dac-form-label" data-t="newsletter.business.games">Games</label>
                    </div>
                    <div class="dac-form-radio-group">
                      <input type="radio" value="Apps and Games" class="dac-form-radio" name="entry.1796324055" id="newsletter-business-type-appsgames" required>
                      <label for="newsletter-business-type-appsgames" class="dac-form-radio-button"></label>
                      <label for="newsletter-business-type-appsgames" class="dac-form-label" data-t="newsletter.business.both">Apps &amp; Games</label>
                    </div>
                  </div>
                  <div class="col-1of2 newsletter-rightCol newsletter-checkboxes">
                    <div class="dac-form-radio-group">
                      <div class="dac-media">
                        <div class="dac-media-figure">
                          <input type="checkbox" class="dac-form-checkbox" name="entry.732309842" id="newsletter-add" required value="Add me to the mailing list for the monthly newsletter and occasional emails about development and Google Play opportunities.">
                          <label for="newsletter-add" class="dac-form-checkbox-button"></label>
                        </div>
                        <div class="dac-media-body">
                          <label for="newsletter-add" class="dac-form-label dac-form-aside"><span data-t="newsletter.confirmMailingList"></span><span class="dac-form-required">*</span></label>
                        </div>
                      </div>
                    </div>
                    <div class="dac-form-radio-group">
                      <div class="dac-media">
                        <div class="dac-media-figure">
                          <input type="checkbox" class="dac-form-checkbox" name="entry.2045036090" id="newsletter-terms" required value="I acknowledge that the information provided in this form will be subject to Google's privacy policy (https://www.google.com/policies/privacy/).">
                          <label for="newsle