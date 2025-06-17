Locators used in code

| Element             | Locator Type       | Locator Value                                                   |
|---------------------|--------------------|------------------------------------------------------------------|
| KeywordInput        | Id                 | new_form_job_search-keyword                                      |
| RemoteInput         | Name               | remote                                                           |
| LocationDropdown    | ClassName          | select2-selection--single                                        |
| SearchInput         | TagName (with wait)| input                                                            |
| CareersLink         | LinkText           | Careers                                                          |
| LatestJobResult     | PartialLinkText    | APPLY                                                            |
| Results             | CssSelector        | .search-results__item a                                          |
| SortByDateButton    | XPath              | .//label[@for='sort-time']                                       |
| FindButton          | XPath              | //button[.//span[contains(text(),'Find')]]                       |
| RemoteLabel         | XPath (from element)| following-sibling::label (from `RemoteInput`)                   |

